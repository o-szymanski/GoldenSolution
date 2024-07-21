using GoldenSolution.DAL.Models;

namespace GoldenSolution.Infrastructure.Services.CareerService;

public interface ICareerService
{
	Task<List<Career>> GetAllCareersAsync();
}
