using Serilog.Sinks.Elasticsearch;
using Serilog;

namespace GoldenSolution.Api.Configurations;

public static class LoggingConfiguration
{
    public static void ConfigureLogging(HostBuilderContext context, LoggerConfiguration configuration)
    {
        configuration.Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"] ?? string.Empty))
        {
            IndexFormat = $"{context.Configuration["ApplicationName"] ?? string.Empty}-{DateTime.UtcNow:yyyy-MM}",
            AutoRegisterTemplate = true,
            NumberOfShards = 2,
            NumberOfReplicas = 1
        })
        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
        .ReadFrom.Configuration(context.Configuration);
    }
}
