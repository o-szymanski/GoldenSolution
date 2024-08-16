using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GoldenSolution.DAL.Models;

public class ApplicationUser : IdentityUser
{
	[Required]
	public override string? Email { get; set; } = string.Empty;
	[Required]
	public override string? NormalizedEmail { get; set; } = string.Empty;
	[Required]
	public override string? UserName { get; set; } = string.Empty;
	[Required]
	public override string? PhoneNumber { get; set; } = string.Empty;
}
