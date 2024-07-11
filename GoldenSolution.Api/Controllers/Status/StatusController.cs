using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Status;

[ApiController]
[Route("api/status")]
public class StatusController : ControllerBase
{
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public IActionResult GetStatus() => Ok();
}
