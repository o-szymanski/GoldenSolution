using GoldenSolution.Core.DTO.Career;
using GoldenSolution.Core.Functions.Queries.Career;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Career;

[ApiController]
[Route("api/careers")]
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
		return careers.Count <= 0 ? NotFound() : Ok(careers);
	}
}
