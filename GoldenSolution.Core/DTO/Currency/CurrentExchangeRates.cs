namespace GoldenSolution.Core.DTO.Currency;

public class CurrentExchangeRates
{
	public string Table { get; set; } = string.Empty;
	public string No { get; set; } = string.Empty;
	public string EffectiveDate { get; set; } = string.Empty;
	public required List<CurrentExchangeRate> Rates { get; set; }
}
