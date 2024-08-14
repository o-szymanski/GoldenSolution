using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Status;

[ApiController]
[Route("api/status")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class StatusController : ControllerBase
{
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public IActionResult GetStatus() => Ok();

	[HttpGet, MapToApiVersion("2.0")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public IActionResult GetStatusV2() => Ok("V2");
}
