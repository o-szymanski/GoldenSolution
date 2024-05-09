using GoldenSolution.Core.DAL;
using GoldenSolution.DAL.Models;
using GoldenSolution.Infrastructure.Mappers.AuthenticationMappers;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Authentication
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class AuthenticationController : ControllerBase
	{
		private readonly IRepository<User> Repository;

		public AuthenticationController(IRepository<User> repository)
		{
			Repository = repository;
		}

		[HttpGet(Name = nameof(GetUserName))]
		public async Task<IActionResult> GetUserName(int userId)
		{
			var user = await Repository.GetById(userId);
			if (user == null) return NotFound();
			return Ok(UserMap.ToUserDto(user));
		}
	}
}
