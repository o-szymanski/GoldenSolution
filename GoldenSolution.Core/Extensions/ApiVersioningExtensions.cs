using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace GoldenSolution.Core.Extensions;

public static class ApiVersioningExtensions
{
	public static void ConfigureApiVersioning(this IServiceCollection services)
	{
		services.AddApiVersioning(options =>
		{
			options.DefaultApiVersion = new ApiVersion(1, 0);
			options.AssumeDefaultVersionWhenUnspecified = true;
			options.ReportApiVersions = true;
			options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");
		}).AddApiExplorer(options =>
		{
			options.GroupNameFormat = "'v'VVV";
			options.SubstituteApiVersionInUrl = true;
		});
	}
}
