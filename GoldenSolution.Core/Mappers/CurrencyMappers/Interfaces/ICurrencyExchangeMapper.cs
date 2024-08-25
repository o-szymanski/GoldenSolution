using GoldenSolution.Core.Entities.DTO.Currency;
using GoldenSolution.Core.Entities.External.Currency;

namespace GoldenSolution.Core.Mappers.UserMappers;

public interface ICurrencyExchangeMapper
{
	public List<CurrencyExchangeDto> Map(List<CurrencyExchange> currencyExchange);
}
