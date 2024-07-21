namespace GoldenSolution.DAL.Models;

public partial class Career
{
	public int Id { get; set; }
	public string Title { get; set; } = null!;
	public string Description { get; set; } = null!;
	public string Location { get; set; } = null!;
	public string Tags { get; set; } = null!;
	public decimal Salary { get; set; }
	public string Contact { get; set; } = null!;
}
