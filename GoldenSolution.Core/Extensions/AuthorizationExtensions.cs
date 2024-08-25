using GoldenSolution.DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoldenSolution.Core.Extensions;

public static class AuthorizationExtensions
{
	public static void AddAuthorization(this IServiceCollection services, IConfiguration _)
	{
		services.AddAuthorization();
		services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<GoldenSolutionDatabaseContext>();
	}
}
