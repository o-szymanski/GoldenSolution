using GoldenSolution.Core.Function.Query;
using GoldenSolution.Core.Models.Currency;
using MediatR;
using System.Net.Http.Json;

namespace GoldenSolution.Infrastructure.Handlers;

public class GetCurrencyExchangeRatesHandler : IRequestHandler<GetCurrencyExchangeRatesQuery, List<CurrencyExchange>>
{
	private readonly IHttpClientFactory _httpClientFactory;

	public GetCurrencyExchangeRatesHandler(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<List<CurrencyExchange>> Handle(GetCurrencyExchangeRatesQuery request, CancellationToken cancellationToken)
	{
		var client = _httpClientFactory.CreateClient("currency");
		var result = await client.GetFromJsonAsync<List<CurrencyExchange>>("", cancellationToken);
		result ??= [];
		return result;
	}
}
