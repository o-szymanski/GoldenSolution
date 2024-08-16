using Asp.Versioning;
using GoldenSolution.Core.DTO.User;
using GoldenSolution.Core.Functions.Commands.User;
using GoldenSolution.Core.Functions.Queries.User;
using GoldenSolution.Core.Inputs.User;
using GoldenSolution.Core.Output.User;
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
		var userDto = await _mediator.Send(new GetUserDataByIdQuery(id));
		return userDto == null ? NotFound() : Ok(userDto);
	}

	[HttpPost("register")]
	[AllowAnonymous]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Register([FromBody] RegisterUserInput registerUser)
	{
		if (registerUser.Password != registerUser.RepeatPassword) return BadRequest("Passwords do not match");

		var result = await _mediator.Send(new RegisterUserCommand(registerUser.Email, registerUser.Password));
		if (!result.Succeeded) return BadRequest(string.Join(", ", result.Errors.Select(e => e.Description)));

		return Ok();
	}

	[HttpPost("login")]
	[AllowAnonymous]
	[ProducesResponseType(typeof(LoginUserResponse), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
	public async Task<IActionResult> Login([FromBody] LoginUserInput loginUserInput)
	{
		var result = await _mediator.Send(new LoginUserCommand(loginUserInput.Email, loginUserInput.Password));
		if (result == null) return Unauthorized("Invalid email or password");
		return Ok(result);
	}
}
