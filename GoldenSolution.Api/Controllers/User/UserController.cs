using GoldenSolution.Core.DTO.User;
using GoldenSolution.Core.Function.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.User;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
	private readonly IMediator _mediator;

	public UserController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet("{id:int}")]
	[ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetUserNameAsync(int id)
	{
		var user = await _mediator.Send(new GetUserNameQuery(id));

		if (user.Id == 0) return NotFound();

		return Ok(user);
	}
}
