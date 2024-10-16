﻿using GoldenSolution.Core.Mappers.CareerMappers;
using GoldenSolution.Core.Mappers.CurrencyMappers;
using GoldenSolution.Core.Mappers.UserMappers;
using GoldenSolution.Core.Mappers.UserMappers.Interfaces;
using GoldenSolution.Infrastructure.Services.CareerService;
using GoldenSolution.Infrastructure.Services.UserService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoldenSolution.Api.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddCustomServices(this IServiceCollection services)
	{
		services.AddHttpClient("currency", client =>
		{
			client.BaseAddress = new Uri(services.BuildServiceProvider().GetRequiredService<IConfiguration>()["NBP"] ?? string.Empty);
		});

		services.AddScoped<IUserService, UserService>();
		services.AddScoped<ICareerService, CareerService>();

        services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        services.AddSingleton<IUserMapper, UserMapper>();
		services.AddSingleton<ICurrencyExchangeMapper, CurrencyExchangeMapper>();
		services.AddSingleton<ICareerMapper, CareerMapper>();
	}
}
