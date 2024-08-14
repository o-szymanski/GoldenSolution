using GoldenSolution.Api.Configurations;
using GoldenSolution.Api.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog(LoggingConfiguration.ConfigureLogging);

builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.AddCustomServices();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.ConfigureApiVersioning();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwaggerDocumentation();
}

app.UseCors("AllowSpecificOrigin");
app.ConfigureExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
