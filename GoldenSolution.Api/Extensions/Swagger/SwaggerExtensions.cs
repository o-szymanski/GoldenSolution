using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace GoldenSolution.Api.Extensions.Swagger;

public static class SwaggerExtensions
{
	public static void AddSwaggerDocumentation(this IServiceCollection services)
	{
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen(options =>
		{
			var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

			foreach (var description in provider.ApiVersionDescriptions)
			{
				var info = new OpenApiInfo()
				{
					Title = description.IsDeprecated ? $"GoldenSolution API {description.ApiVersion} (Deprecated)" : $"GoldenSolution API {description.ApiVersion}",
					Version = description.ApiVersion.ToString(),
					Description = description.IsDeprecated ? "This API version has been deprecated and may be removed in future versions." : "This API version is the current version."
				};

				options.SwaggerDoc(description.GroupName, info);
			}

			options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
			{
				In = ParameterLocation.Header,
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey
			});

			options.OperationFilter<SecurityRequirementsOperationFilter>();

			options.OperationFilter<SwaggerDefaultValues>();
		});
	}

	public static void UseSwaggerDocumentation(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
	{
		app.UseSwagger();
		app.UseSwaggerUI(options =>
		{
			foreach (var description in provider.ApiVersionDescriptions)
			{
				options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
				options.DefaultModelExpandDepth(2);
				options.DefaultModelsExpandDepth(-1);
			}
		});
	}
}
