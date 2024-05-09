using GoldenSolution.DAL.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using GoldenSolution.Core.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddSingleton(typeof(IRepository<>), typeof(RepositoryBase<>));
builder.Services.AddSingleton(typeof(DbContext), typeof(GoldenSolutionDatabaseContext));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
