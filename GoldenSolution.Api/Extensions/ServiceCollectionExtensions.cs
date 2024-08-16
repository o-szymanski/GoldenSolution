using GoldenSolution.Core.Mappers.CareerMappers;
using GoldenSolution.Core.Mappers.CurrencyMappers;
using GoldenSolution.Core.Mappers.UserMappers;
using GoldenSolution.Infrastructure.Handlers;
using GoldenSolution.Infrastructure.Services.CareerService;
using GoldenSolution.Infrastructure.Services.UserService;

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

		services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetUserNameByIdHandler).Assembly));

		services.AddSingleton<IUserMapper, UserMapper>();
		services.AddSingleton<ICurrencyExchangeMapper, CurrencyExchangeMapper>();
		services.AddSingleton<ICareerMapper, CareerMapper>();
	}
}
