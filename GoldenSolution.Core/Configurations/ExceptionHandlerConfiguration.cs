using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace GoldenSolution.Core.Configurations;

public static class ExceptionHandlerConfiguration
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null) Log.Logger.Error("{path} / {message} / {stacktrace}", contextFeature.Path, contextFeature.Error.Message, contextFeature.Error.StackTrace);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new
                {
                    context.Response.StatusCode,
                    Message = "Internal Server Error"
                });
            });
        });
    }
}
