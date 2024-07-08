using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Status;

[ApiController]
[Route("api/status")]
public class StatusController : ControllerBase
{
	[HttpGet]
	[Route("")]
	public Task<IActionResult> GetStatus() => Task.FromResult<IActionResult>(Ok());
}
