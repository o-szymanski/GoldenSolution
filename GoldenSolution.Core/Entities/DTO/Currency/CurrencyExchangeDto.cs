namespace GoldenSolution.Core.Entities.DTO.Currency;

public record CurrencyExchangeDto(string Table, string No, string EffectiveDate, List<RateDto> Rates);
