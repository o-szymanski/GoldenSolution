using GoldenSolution.Core.Models.DTO.Currency;
using GoldenSolution.Core.Models.External.Currency;

namespace GoldenSolution.Core.Mappers.UserMappers;

public interface ICurrencyExchangeMapper
{
	public List<CurrencyExchangeDto> Map(List<CurrencyExchange> currencyExchange);
}
