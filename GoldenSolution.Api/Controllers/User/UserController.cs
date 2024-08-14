using Asp.Versioning;
using GoldenSolution.Core.DTO.User;
using GoldenSolution.Core.Functions.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.User;

[ApiController]
[Route("api/users")]
[ApiVersion("1.0", Deprecated = true)]
[ApiVersion("2.0")]
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
	public async Task<IActionResult> GetUserNameByIdAsync(int id)
	{
		var user = await _mediator.Send(new GetUserNameByIdQuery(id));
		return user.Id == 0 ? NotFound() : Ok(user);
	}
}
