using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.RateLimiting;

namespace GoldenSolution.Core.Configurations
{
    public static class RateLimitingConfiguration
    {
        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                options.AddPolicy("RegisterLimiter", HttpContext => RateLimitPartition.GetFixedWindowLimiter(partitionKey: HttpContext.Connection.RemoteIpAddress?.ToString(), factory: _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 5,
                    Window = TimeSpan.FromMinutes(1)
                }));

                options.AddPolicy("LoginLimiter", HttpContext => RateLimitPartition.GetFixedWindowLimiter(partitionKey: HttpContext.Connection.RemoteIpAddress?.ToString(), factory: _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 10,
                    Window = TimeSpan.FromMinutes(1)
                }));
            });
        }
    }
}
