using GoldenSolution.DAL.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using GoldenSolution.Core.DAL;
using MediatR;
using GoldenSolution.Infrastructure.Handlers;
using GoldenSolution.Core.Function.Query;
using Microsoft.AspNetCore.Diagnostics;
using GoldenSolution.Core.External.Currency;
using GoldenSolution.Core.Mappers.CurrencyMappers;
using GoldenSolution.Core.Mappers.UserMappers;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using GoldenSolution.Core.DTO.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin", builder =>
	{
		builder.WithOrigins("http://localhost:5173")
		.AllowAnyHeader()
		.AllowAnyMethod();
	});
});

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
builder.Services.AddTransient<IRequestHandler<GetCurrencyExchangeRatesQuery, List<CurrencyExchangeDto>>, GetCurrencyExchangeRatesHandler>();

builder.Services.AddHttpClient("currency", client =>
{
	client.BaseAddress = new Uri(builder.Configuration["NBP"] ?? string.Empty);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped(typeof(DbContext), typeof(GoldenSolutionDatabaseContext));

builder.Services.AddSingleton<UserMapper>();
builder.Services.AddSingleton<CurrencyExchangeMapper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseExceptionHandler(error =>
{
	error.Run(async context =>
	{
		var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
		if (contextFeature != null) Log.Logger.Error("{path} / {message} / {stacktrace}", contextFeature.Path, contextFeature.Error.Message, contextFeature.Error.StackTrace);
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
