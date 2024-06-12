namespace GoldenSolution.Core.DTO.Currency;

public class CurrentExchangeRate
{
	public string Currency { get; set; } = string.Empty;
	public string Code { get; set; } = string.Empty;
	public double Mid { get; set; }
}
