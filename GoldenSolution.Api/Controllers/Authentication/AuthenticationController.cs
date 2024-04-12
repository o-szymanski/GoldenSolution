using GoldenSolution.Infrastructure.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Authentication
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class AuthenticationController : ControllerBase
	{
		private readonly IUserService _userService;

		public AuthenticationController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet(Name = nameof(GetUser))]
		public IActionResult GetUser(string userId)
		{
			var result = _userService.GetUser(userId);
			return Ok(result);
		}
	}
}
