using GoldenSolution.Core.Function.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Currency;

[ApiController]
[Route("[controller]/[action]")]
public class CurrencyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CurrencyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = nameof(GetCurrencyExchangeRates))]
    public async Task<IActionResult> GetCurrencyExchangeRates()
    {
        var request = new GetCurrencyExchangeRatesQuery();

        var currencyExchangeRates = await _mediator.Send(request);
        if (currencyExchangeRates.Count < 1) return NotFound();

        return Ok(currencyExchangeRates);
    }
}
