using Asp.Versioning;
using GoldenSolution.Core.Functions.Commands.User;
using GoldenSolution.Core.Functions.Queries.User;
using GoldenSolution.Core.Models.DTO.User;
using GoldenSolution.Core.Models.Requests.User;
using GoldenSolution.Core.Models.Responses.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.User;

[ApiController, Authorize]
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

	[HttpGet("{id}")]
	[ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetUserDataById(string id)
	{
		var user = await _mediator.Send(new GetUserDataByIdQuery(id));
		return user is null ? NotFound() : Ok(user);
	}

	[HttpPost("register")]
	[AllowAnonymous]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Register([FromBody] RegisterUserRequest registerUserRequest)
	{
		var result = await _mediator.Send(new RegisterUserCommand(registerUserRequest.Email, registerUserRequest.Password));
		return !result.Succeeded ? BadRequest(string.Join(", ", result.Errors.Select(e => e.Description))) : Ok();
	}

	[HttpPost("login")]
	[AllowAnonymous]
	[ProducesResponseType(typeof(LoginUserResponse), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
	public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserRequest)
	{
		var result = await _mediator.Send(new LoginUserCommand(loginUserRequest.Email, loginUserRequest.Password));
		return result is null ? Unauthorized("Invalid email or password") : Ok(result);
	}
}
