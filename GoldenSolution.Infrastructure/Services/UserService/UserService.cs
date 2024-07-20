using GoldenSolution.DAL.Models;

namespace GoldenSolution.Infrastructure.Services.UserService;

public class UserService : IUserService
{
	private readonly GoldenSolutionDatabaseContext _goldenSolutionDatabaseContext;

	public UserService(GoldenSolutionDatabaseContext goldenSolutionDatabaseContext)
	{
		_goldenSolutionDatabaseContext = goldenSolutionDatabaseContext;
	}

	public async Task<User?> GetUserByIdAsync(int id)
	{
		return await _goldenSolutionDatabaseContext.Users.FindAsync(id);
	}
}
