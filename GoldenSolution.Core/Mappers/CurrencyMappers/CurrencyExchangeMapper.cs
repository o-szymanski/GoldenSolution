using GoldenSolution.Core.Mappers.UserMappers;
using GoldenSolution.Core.Models.DTO.Currency;
using GoldenSolution.Core.Models.External.Currency;
using Riok.Mapperly.Abstractions;

namespace GoldenSolution.Core.Mappers.CurrencyMappers;

[Mapper]
public partial class CurrencyExchangeMapper : ICurrencyExchangeMapper
{
	public partial List<CurrencyExchangeDto> Map(List<CurrencyExchange> currencyExchange);
}
