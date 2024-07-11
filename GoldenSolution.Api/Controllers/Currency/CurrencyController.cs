using GoldenSolution.Core.External.Currency;
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
	[ProducesResponseType(typeof(CurrencyExchangeDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetCurrencyExchangeRates()
    {
        var currencyExchangeRates = await _mediator.Send(new GetCurrencyExchangeRatesQuery());

        if (currencyExchangeRates.Count < 1) return NotFound();

        return Ok(currencyExchangeRates);
    }
}
