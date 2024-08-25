using Microsoft.Extensions.DependencyInjection;

namespace GoldenSolution.Core.Extensions;

public static class CorsExtensions
{
	public static void ConfigureCors(this IServiceCollection services)
	{
		services.AddCors(options =>
		{
			options.AddPolicy("AllowSpecificOrigin", builder =>
			{
				builder.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
			});
		});
	}
}
