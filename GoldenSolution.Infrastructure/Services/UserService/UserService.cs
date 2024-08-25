using GoldenSolution.Core.Models.Responses.User;
using GoldenSolution.DAL.Models;
using GoldenSolution.Infrastructure.Services.UserService.Helpers;
using Microsoft.AspNetCore.Identity;

namespace GoldenSolution.Infrastructure.Services.UserService;

public class UserService : IUserService
{
	private readonly UserManager<ApplicationUser> _userManager;

	public UserService(UserManager<ApplicationUser> userManager)
	{
		_userManager = userManager;
	}

	public async Task<ApplicationUser?> GetUserByIdAsync(string id)
	{
		return await _userManager.FindByIdAsync(id);
	}

	public async Task<IdentityResult> RegisterUserAsync(string email, string password)
	{
		var applicationUser = new ApplicationUser { UserName = email, Email = email };
		return await _userManager.CreateAsync(applicationUser, password);
	}

	public async Task<LoginUserResponse?> LoginUserAsync(string email, string password, string jwtKey, string issuer)
	{
		var applicationUser = await _userManager.FindByEmailAsync(email);
		if (applicationUser is null) return null;

		var passwordValid = await _userManager.CheckPasswordAsync(applicationUser, password);
		if (passwordValid is not true) return null;

		var accessToken = UserHelper.GenerateJwtToken(applicationUser, jwtKey, issuer);

		return new LoginUserResponse
		{
			TokenType = "Bearer",
			AccessToken = accessToken,
			ExpiresIn = 3600,
			RefreshToken = UserHelper.GenerateRefreshToken()
		};
	}
}
