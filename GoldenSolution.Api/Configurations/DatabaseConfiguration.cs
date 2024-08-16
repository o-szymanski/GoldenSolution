using GoldenSolution.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenSolution.Api.Configurations;

public static class DatabaseConfiguration
{
	public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<GoldenSolutionDatabaseContext>(options =>
		{
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ?? string.Empty);
		});
	}

	public static void AddIdentity(this IServiceCollection services)
	{
		services.AddAuthorization();
		services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<GoldenSolutionDatabaseContext>();
	}
}
