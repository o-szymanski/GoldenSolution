using GoldenSolution.Core.ExternalModels.Currency;
using Riok.Mapperly.Abstractions;

namespace GoldenSolution.Core.Mappers.CurrencyMappers;

[Mapper]
public partial class CurrencyExchangeMapper
{
	public partial List<CurrencyExchangeDto> Map(List<CurrencyExchange> currencyExchange);
}
