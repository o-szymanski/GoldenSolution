using GoldenSolution.Core.Output.User;
using GoldenSolution.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace GoldenSolution.Infrastructure.Services.UserService;

public interface IUserService
{
	Task<ApplicationUser?> GetUserByIdAsync(string id);
	Task<IdentityResult> RegisterUserAsync(string email, string password);
	Task<LoginUserResponse?> LoginUserAsync(string email, string password, string key, string iisuer);
}
