using GoldenSolution.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace GoldenSolution.Infrastructure.Services.UserService;

public class UserService : IUserService
{
	private readonly UserManager<User> _userManager;

	public UserService(UserManager<User> userManager)
	{
		_userManager = userManager;
	}

	public async Task<User?> GetUserByIdAsync(string id)
	{
		return await _userManager.FindByIdAsync(id);
	}
}
