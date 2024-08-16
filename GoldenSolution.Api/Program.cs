using Asp.Versioning.ApiExplorer;
using GoldenSolution.Api.Configurations;
using GoldenSolution.Api.Extensions;
using GoldenSolution.Api.Extensions.Swagger;
using GoldenSolution.DAL.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog(LoggingConfiguration.ConfigureLogging);

builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.AddCustomServices();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddIdentity();
builder.Services.AddSwaggerDocumentation();
builder.Services.ConfigureApiVersioning();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
	app.UseSwaggerDocumentation(apiVersionDescriptionProvider);
}

app.UseCors("AllowSpecificOrigin");
app.MapIdentityApi<User>();
app.ConfigureExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
