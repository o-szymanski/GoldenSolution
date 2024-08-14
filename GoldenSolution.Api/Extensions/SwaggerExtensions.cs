namespace GoldenSolution.Api.Extensions;

public static class SwaggerExtensions
{
	public static void AddSwaggerDocumentation(this IServiceCollection services)
	{
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();
	}

	public static void UseSwaggerDocumentation(this IApplicationBuilder app)
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}
}
