using GoldenSolution.DAL.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using GoldenSolution.Core.DAL;
using MediatR;
using GoldenSolution.Infrastructure.Handlers;
using GoldenSolution.Core.DTO.Authentication;
using GoldenSolution.Core.Function.Query;
using Microsoft.AspNetCore.Diagnostics;
using GoldenSolution.Core.ExternalModels.Currency;
using GoldenSolution.Core.Mappers.CurrencyMappers;
using GoldenSolution.Core.Mappers.AuthenticationMappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddTransient<IRequestHandler<GetUserNameQuery, UserDto>, GetUserNameHandler>();
builder.Services.AddTransient<IRequestHandler<GetCurrencyExchangeRatesQuery, List<CurrencyExchangeDto>>, GetCurrencyExchangeRatesHandler>();

builder.Services.AddHttpClient("currency", client =>
{
	client.BaseAddress = new Uri("https://api.nbp.pl/api/exchangerates/tables/a/?format=json");
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

app.UseExceptionHandler(error =>
{
	error.Run(async context =>
	{
		var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
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
