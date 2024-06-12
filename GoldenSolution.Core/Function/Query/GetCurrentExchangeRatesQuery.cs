using GoldenSolution.Core.DTO.Currency;
using MediatR;

namespace GoldenSolution.Core.Function.Query;

public class GetCurrentExchangeRatesQuery : IRequest<List<CurrentExchangeRates>> { }
