namespace GoldenSolution.Core.Models.Currency;

public class Rates
{
    public string Currency { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public double Mid { get; set; }
}
