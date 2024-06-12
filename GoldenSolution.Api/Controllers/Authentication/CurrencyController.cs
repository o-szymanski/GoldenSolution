using GoldenSolution.Core.Function.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Authentication;

[ApiController]
[Route("[controller]/[action]")]
public class CurrencyController : ControllerBase
{
	private readonly IMediator _mediator;

	public CurrencyController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet(Name = nameof(GetActualCurrency))]
	public async Task<IActionResult> GetActualCurrency()
	{
		var request = new GetCurrentExchangeRatesQuery();

		var currentExchangeRates = await _mediator.Send(request);
		if (currentExchangeRates.Count < 1) return NotFound();

		return Ok(currentExchangeRates);
	}
}
