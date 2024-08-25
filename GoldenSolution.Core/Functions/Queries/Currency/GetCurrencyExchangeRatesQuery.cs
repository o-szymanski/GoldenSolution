using GoldenSolution.Core.Models.DTO.Currency;
using MediatR;

namespace GoldenSolution.Core.Functions.Queries.Currency;

public record GetCurrencyExchangeRatesQuery : IRequest<List<CurrencyExchangeDto>?>;
