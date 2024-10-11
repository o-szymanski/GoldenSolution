using GoldenSolution.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Serilog;

namespace GoldenSolution.Core.Configurations;

public static class DatabaseConfiguration
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GoldenSolutionDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ?? string.Empty);
        });
    }

    public static void MigrateDatabase(this IServiceProvider serviceProvider)
    {
        var retryPolicy = Policy.Handle<Exception>()
        .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(5), (exception, timeSpan, retryCount, context) =>
        {
            Log.Logger.Warning("Retry {RetryCount} for database migration due to error: {ErrorMessage}. Retrying in {RetryTime}...", retryCount, exception.Message, timeSpan);
        });

        try
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<GoldenSolutionDatabaseContext>();
            retryPolicy.Execute(context.Database.Migrate);
        }
        catch (Exception ex)
        {
            Log.Logger.Error("An error occurred during database migration. Message: {Message}, StackTrace: {StackTrace}", ex.Message, ex.StackTrace);
            throw;
        }
    }
}
