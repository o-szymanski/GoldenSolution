using GoldenSolution.Core.Function.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Currency;

[ApiController]
[Route("api/currencies")]
public class CurrencyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CurrencyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
	[Route("")]
	public async Task<IActionResult> GetCurrencyExchangeRates()
    {
        var request = new GetCurrencyExchangeRatesQuery();

        var currencyExchangeRates = await _mediator.Send(request);
        if (currencyExchangeRates.Count < 1) return NotFound();

        return Ok(currencyExchangeRates);
    }
}
