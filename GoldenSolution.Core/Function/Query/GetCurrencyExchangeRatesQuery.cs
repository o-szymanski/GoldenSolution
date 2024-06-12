using GoldenSolution.Core.Models.Currency;
using MediatR;

namespace GoldenSolution.Core.Function.Query;

public class GetCurrencyExchangeRatesQuery : IRequest<List<CurrencyExchange>> { }
