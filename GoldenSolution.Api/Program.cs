using GoldenSolution.DAL.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using GoldenSolution.Core.DAL;
using MediatR;
using GoldenSolution.Infrastructure.Handlers;
using GoldenSolution.Core.DTO.Authentication;
using GoldenSolution.Core.Function.Query;
using GoldenSolution.Core.Models.Currency;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

builder.Host.UseSerilog((context, configuration) =>
{
	configuration.Enrich.FromLogContext()
	.Enrich.WithMachineName()
	.WriteTo.Console()
	.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"] ?? string.Empty))
	{
		IndexFormat = $"{context.Configuration["ApplicationName"] ?? string.Empty}-{DateTime.UtcNow:yyyy-MM}",
		AutoRegisterTemplate = true,
		NumberOfShards = 2,
		NumberOfReplicas = 1
	})
	.Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
	.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddTransient<IRequestHandler<GetUserNameQuery, UserDto>, GetUserNameHandler>();
builder.Services.AddTransient<IRequestHandler<GetCurrencyExchangeRatesQuery, List<CurrencyExchange>>, GetCurrencyExchangeRatesHandler>();

builder.Services.AddHttpClient("currency", client =>
{
	client.BaseAddress = new Uri(builder.Configuration["NBP"] ?? string.Empty);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped(typeof(DbContext), typeof(GoldenSolutionDatabaseContext));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseExceptionHandler(error =>
{
	error.Run(async context =>
	{
		var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
		if (contextFeature != null) Log.Logger.Error($"{contextFeature.Path} {contextFeature.Error.Message} {contextFeature.Error.StackTrace}", "Internal Server Error");
		await context.Response.WriteAsJsonAsync(new
		{
			context.Response.StatusCode,
			Message = "Internal Server Error"
		});
	});
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
