using GoldenSolution.Core.DTO.Currency;
using GoldenSolution.Core.External.Currency;

namespace GoldenSolution.Core.Mappers.UserMappers;

public interface ICurrencyExchangeMapper
{
	public List<CurrencyExchangeDto> Map(List<CurrencyExchange> currencyExchange);
}
