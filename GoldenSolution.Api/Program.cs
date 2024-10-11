using Asp.Versioning.ApiExplorer;
using GoldenSolution.Core.Configurations;
using GoldenSolution.Api.Extensions;
using GoldenSolution.Api.Extensions.Swagger;
using Serilog;
using GoldenSolution.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog(LoggingConfiguration.ConfigureLogging);

builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.AddCustomServices();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddAuthorization(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureRateLimiting();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwaggerDocumentation(apiVersionDescriptionProvider);
}

app.Services.MigrateDatabase();
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.ConfigureExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.MapControllers();

app.Run();