using GoldenSolution.Core.DTO.Currency;
using GoldenSolution.Core.Function.Query;
using MediatR;
using System.Net.Http.Json;

namespace GoldenSolution.Infrastructure.Handlers;

public class GetCurrentExchangeRatesHandler : IRequestHandler<GetCurrentExchangeRatesQuery, List<CurrentExchangeRates>>
{
	private readonly IHttpClientFactory _httpClientFactory;

	public GetCurrentExchangeRatesHandler(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<List<CurrentExchangeRates>> Handle(GetCurrentExchangeRatesQuery request, CancellationToken cancellationToken)
	{
		var client = _httpClientFactory.CreateClient("currency");
		var result = await client.GetFromJsonAsync<List<CurrentExchangeRates>>("", cancellationToken);
		result ??= [];
		return result;
	}
}
