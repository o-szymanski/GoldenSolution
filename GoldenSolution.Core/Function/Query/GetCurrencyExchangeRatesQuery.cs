using GoldenSolution.Core.External.Currency;
using MediatR;

namespace GoldenSolution.Core.Function.Query;

public record GetCurrencyExchangeRatesQuery : IRequest<List<CurrencyExchangeDto>>;
