using GoldenSolution.DAL.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MediatR;
using GoldenSolution.Infrastructure.Handlers;
using Microsoft.AspNetCore.Diagnostics;
using GoldenSolution.Core.Mappers.CurrencyMappers;
using GoldenSolution.Core.Mappers.UserMappers;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using GoldenSolution.Core.Mappers.CareerMappers;
using GoldenSolution.Core.DTO.Career;
using GoldenSolution.Infrastructure.Services.UserService;
using GoldenSolution.Infrastructure.Services.CareerService;
using GoldenSolution.Core.DTO.User;
using GoldenSolution.Core.DTO.Currency;
using GoldenSolution.Core.Functions.Queries.User;
using GoldenSolution.Core.Functions.Queries.Career;
using GoldenSolution.Core.Functions.Queries.Currency;

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

builder.Services.AddTransient<IRequestHandler<GetUserNameByIdQuery, UserDto>, GetUserNameByIdHandler>();
builder.Services.AddTransient<IRequestHandler<GetCurrencyExchangeRatesQuery, List<CurrencyExchangeDto>>, GetCurrencyExchangeRatesHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllCareerQuery, List<CareerDto>>, GetAllCareerHandler>();

builder.Services.AddHttpClient("currency", client =>
{
	client.BaseAddress = new Uri(builder.Configuration["NBP"] ?? string.Empty);
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICareerService, CareerService>();

builder.Services.AddDbContext<GoldenSolutionDatabaseContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty);
});

builder.Services.AddSingleton<UserMapper>();
builder.Services.AddSingleton<CurrencyExchangeMapper>();
builder.Services.AddSingleton<CareerMapper>();

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
		if (contextFeature is not null) Log.Logger.Error("{path} / {message} / {stacktrace}", contextFeature.Path, contextFeature.Error.Message, contextFeature.Error.StackTrace);
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
