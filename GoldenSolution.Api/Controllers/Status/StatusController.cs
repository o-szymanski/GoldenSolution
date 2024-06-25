using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Status;

[ApiController]
[Route("[controller]/[action]")]
public class StatusController : ControllerBase
{
	[HttpGet(Name = nameof(GetStatus))]
	public Task<IActionResult> GetStatus() => Task.FromResult<IActionResult>(Ok("Ok"));
}
