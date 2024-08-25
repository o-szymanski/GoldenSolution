namespace GoldenSolution.Core.Models.External.Currency;

public record CurrencyExchange(string Table, string No, string EffectiveDate, List<Rate> Rates);
