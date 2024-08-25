using GoldenSolution.Core.Entities.DTO.Currency;
using GoldenSolution.Core.Entities.External.Currency;
using GoldenSolution.Core.Functions.Queries.Currency;
using GoldenSolution.Core.Mappers.UserMappers;
using MediatR;
using System.Net.Http.Json;

namespace GoldenSolution.Infrastructure.Handlers.Currency;

public class GetCurrencyExchangeRatesHandler : IRequestHandler<GetCurrencyExchangeRatesQuery, List<CurrencyExchangeDto>?>
{
    private readonly HttpClient _httpClient;
    private readonly ICurrencyExchangeMapper _currencyExchangeMapper;

    public GetCurrencyExchangeRatesHandler(IHttpClientFactory httpClientFactory, ICurrencyExchangeMapper currencyExchangeMapper)
    {
        _httpClient = httpClientFactory.CreateClient("currency");
        _currencyExchangeMapper = currencyExchangeMapper;
    }

    public async Task<List<CurrencyExchangeDto>?> Handle(GetCurrencyExchangeRatesQuery request, CancellationToken cancellationToken)
    {
        var result = await _httpClient.GetFromJsonAsync<List<CurrencyExchange>>(string.Empty, cancellationToken);
        return result is null || result.Count is 0 ? null : _currencyExchangeMapper.Map(result);
    }
}
