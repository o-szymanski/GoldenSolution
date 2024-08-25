using GoldenSolution.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
}
