namespace GoldenSolution.Core.ExternalModels.Currency;

public class RatesDto
{
	public string Currency { get; set; } = string.Empty;
	public string Code { get; set; } = string.Empty;
	public double Mid { get; set; }
}
