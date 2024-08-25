using Asp.Versioning;
using GoldenSolution.Core.Functions.Queries.Career;
using GoldenSolution.Core.Models.DTO.Career;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Career;

[ApiController, Authorize]
[Route("api/careers")]
[ApiVersion("1.0", Deprecated = true)]
[ApiVersion("2.0")]
public class CareerController : ControllerBase
{
	private readonly IMediator _mediator;

	public CareerController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	[ProducesResponseType(typeof(List<CareerDto>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetCareersAsync()
	{
		var careers = await _mediator.Send(new GetAllCareerQuery());
		return careers is null ? NotFound() : Ok(careers);
	}
}
