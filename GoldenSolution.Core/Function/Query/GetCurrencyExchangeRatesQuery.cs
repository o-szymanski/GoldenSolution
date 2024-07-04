using GoldenSolution.Core.ExternalModels.Currency;
using MediatR;

namespace GoldenSolution.Core.Function.Query;

public class GetCurrencyExchangeRatesQuery : IRequest<List<CurrencyExchangeDto>> { }
