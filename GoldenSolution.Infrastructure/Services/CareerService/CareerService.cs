using GoldenSolution.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenSolution.Infrastructure.Services.CareerService;

public class CareerService : ICareerService
{
	private readonly GoldenSolutionDatabaseContext _goldenSolutionDatabaseContext;

	public CareerService(GoldenSolutionDatabaseContext goldenSolutionDatabaseContext)
	{
		_goldenSolutionDatabaseContext = goldenSolutionDatabaseContext;
	}

	public async Task<List<Career>> GetAllCareersAsync()
	{
		return await _goldenSolutionDatabaseContext.Careers.ToListAsync();
	}
}
