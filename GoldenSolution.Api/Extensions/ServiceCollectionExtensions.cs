using GoldenSolution.Core.DTO.Career;
using GoldenSolution.Core.DTO.Currency;
using GoldenSolution.Core.DTO.User;
using GoldenSolution.Core.Functions.Queries.Career;
using GoldenSolution.Core.Functions.Queries.Currency;
using GoldenSolution.Core.Functions.Queries.User;
using GoldenSolution.Core.Mappers.CareerMappers;
using GoldenSolution.Core.Mappers.CurrencyMappers;
using GoldenSolution.Core.Mappers.UserMappers;
using GoldenSolution.Infrastructure.Handlers;
using GoldenSolution.Infrastructure.Services.CareerService;
using GoldenSolution.Infrastructure.Services.UserService;
using MediatR;
using System.Reflection;

namespace GoldenSolution.Api.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddCustomServices(this IServiceCollection services)
	{
		services.AddTransient<IRequestHandler<GetUserNameByIdQuery, UserDto>, GetUserNameByIdHandler>();
		services.AddTransient<IRequestHandler<GetCurrencyExchangeRatesQuery, List<CurrencyExchangeDto>>, GetCurrencyExchangeRatesHandler>();
		services.AddTransient<IRequestHandler<GetAllCareerQuery, List<CareerDto>>, GetAllCareerHandler>();

		services.AddHttpClient("currency", client =>
		{
			client.BaseAddress = new Uri(services.BuildServiceProvider().GetRequiredService<IConfiguration>()["NBP"] ?? string.Empty);
		});

		services.AddScoped<IUserService, UserService>();
		services.AddScoped<ICareerService, CareerService>();

		services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

		services.AddSingleton<IUserMapper, UserMapper>();
		services.AddSingleton<ICurrencyExchangeMapper, CurrencyExchangeMapper>();
		services.AddSingleton<ICareerMapper, CareerMapper>();
	}
}
