using GoldenSolution.DAL.Models;

namespace GoldenSolution.Infrastructure.Services.UserService;

public interface IUserService
{
	Task<User?> GetUserByIdAsync(int id);
}
