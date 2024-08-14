using GoldenSolution.Core.DTO.Currency;
using GoldenSolution.Core.External.Currency;
using GoldenSolution.Core.Functions.Queries.Currency;
using GoldenSolution.Core.Mappers.UserMappers;
using MediatR;
using System.Net.Http.Json;

namespace GoldenSolution.Infrastructure.Handlers;

public class GetCurrencyExchangeRatesHandler : IRequestHandler<GetCurrencyExchangeRatesQuery, List<CurrencyExchangeDto>>
{
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly ICurrencyExchangeMapper _currencyExchangeMapper;

	public GetCurrencyExchangeRatesHandler(IHttpClientFactory httpClientFactory, ICurrencyExchangeMapper currencyExchangeMapper)
	{
		_httpClientFactory = httpClientFactory;
		_currencyExchangeMapper = currencyExchangeMapper;
	}

	public async Task<List<CurrencyExchangeDto>> Handle(GetCurrencyExchangeRatesQuery request, CancellationToken cancellationToken)
	{
		var client = _httpClientFactory.CreateClient("currency");
		var result = await client.GetFromJsonAsync<List<CurrencyExchange>>(string.Empty, cancellationToken);
		return result is null ? [] : _currencyExchangeMapper.Map(result);
	}
}
