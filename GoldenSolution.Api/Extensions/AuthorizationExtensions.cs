using GoldenSolution.DAL.Models;

namespace GoldenSolution.Api.Extensions;

public static class AuthorizationExtensions
{
	public static void AddAuthorization(this IServiceCollection services, IConfiguration _)
	{
		services.AddAuthorization();
		services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<GoldenSolutionDatabaseContext>();
	}
}
