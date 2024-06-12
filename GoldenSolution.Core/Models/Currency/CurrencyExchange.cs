namespace GoldenSolution.Core.Models.Currency;

public class CurrencyExchange
{
    public string Table { get; set; } = string.Empty;
    public string No { get; set; } = string.Empty;
    public string EffectiveDate { get; set; } = string.Empty;
    public required List<Rates> Rates { get; set; }
}
