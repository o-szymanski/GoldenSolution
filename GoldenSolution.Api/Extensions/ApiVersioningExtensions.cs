using Asp.Versioning;

namespace GoldenSolution.Api.Extensions;

public static class ApiVersioningExtensions
{
	public static void ConfigureApiVersioning(this IServiceCollection services)
	{
		var apiVersioningBuilder = services.AddApiVersioning(options =>
		{
			options.DefaultApiVersion = new ApiVersion(1, 0);
			options.AssumeDefaultVersionWhenUnspecified = true;
			options.ReportApiVersions = true;
			options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");
		});

		apiVersioningBuilder.AddApiExplorer(options =>
		{
			options.GroupNameFormat = "'v'VVV";
			options.SubstituteApiVersionInUrl = true;
		});
	}
}
