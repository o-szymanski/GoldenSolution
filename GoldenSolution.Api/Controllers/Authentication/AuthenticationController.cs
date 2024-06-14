using GoldenSolution.Core.Function.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Authentication;

[ApiController]
[Route("[controller]/[action]")]
public class AuthenticationController : ControllerBase
{
	private readonly IMediator _mediator;

	public AuthenticationController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet(Name = nameof(GetUserName))]
	public async Task<IActionResult> GetUserName(int userId)
	{
		var request = new GetUserNameQuery
		{
			Id = userId,
		};

		var user = await _mediator.Send(request);
		if (user.Id == 0) return NotFound();

		return Ok(user);
	}
}
