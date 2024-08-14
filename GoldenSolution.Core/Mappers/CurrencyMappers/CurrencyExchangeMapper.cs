using GoldenSolution.Core.DTO.Currency;
using GoldenSolution.Core.External.Currency;
using GoldenSolution.Core.Mappers.UserMappers;
using Riok.Mapperly.Abstractions;

namespace GoldenSolution.Core.Mappers.CurrencyMappers;

[Mapper]
public partial class CurrencyExchangeMapper : ICurrencyExchangeMapper
{
	public partial List<CurrencyExchangeDto> Map(List<CurrencyExchange> currencyExchange);
}
