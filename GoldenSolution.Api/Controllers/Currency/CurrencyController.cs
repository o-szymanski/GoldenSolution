using Asp.Versioning;
using GoldenSolution.Core.DTO.Currency;
using GoldenSolution.Core.Functions.Queries.Currency;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Api.Controllers.Currency;

[ApiController, Authorize]
[Route("api/currencies")]
[ApiVersion("1.0", Deprecated = true)]
[ApiVersion("2.0")]
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
	public async Task<IActionResult> GetCurrencyExchangeRatesAsync()
	{
		var currencyExchangeRates = await _mediator.Send(new GetCurrencyExchangeRatesQuery());
        return currencyExchangeRates is null ? NotFound() : Ok(currencyExchangeRates);
    }
}
