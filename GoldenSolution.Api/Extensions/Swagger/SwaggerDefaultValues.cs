using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GoldenSolution.Api.Extensions.Swagger;

public class SwaggerDefaultValues : IOperationFilter
{
	public void Apply(OpenApiOperation operation, OperationFilterContext context)
	{
		var apiVersion = context.ApiDescription.GroupName;
		if (!string.IsNullOrEmpty(apiVersion))
		{
			var versionNumber = apiVersion.Last().ToString();
			var parameter = operation.Parameters.FirstOrDefault(p => p.Name == "X-API-Version");

			if (parameter != null)
			{
				parameter.Description ??= "The API version to use.";
				parameter.Schema.Default = new OpenApiString(versionNumber);
				parameter.Required = true;
			}
		}
	}
}
