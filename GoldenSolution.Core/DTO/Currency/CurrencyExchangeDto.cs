namespace GoldenSolution.Core.External.Currency;

public record CurrencyExchangeDto(string Table, string No, string EffectiveDate, List<RatesDto> Rates);
