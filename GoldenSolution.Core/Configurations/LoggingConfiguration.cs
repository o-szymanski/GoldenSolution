using Serilog.Sinks.Elasticsearch;
using Serilog;
using Microsoft.Extensions.Hosting;

namespace GoldenSolution.Core.Configurations;

public static class LoggingConfiguration
{
	public static void ConfigureLogging(HostBuilderContext context, LoggerConfiguration configuration)
	{
		configuration.Enrich.FromLogContext()
		.Enrich.WithMachineName()
		.WriteTo.Console()
		.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"] ?? string.Empty))
		{
			IndexFormat = string.Format("{0}-{1:yyyy-MM}", context.Configuration["ApplicationName"] ?? string.Empty, DateTime.UtcNow),
			AutoRegisterTemplate = true,
			NumberOfShards = 2,
			NumberOfReplicas = 1
		})
		.Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
		.ReadFrom.Configuration(context.Configuration);
	}
}
