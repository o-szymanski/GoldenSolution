using GoldenSolution.Core.Models.DTO.Career;
using GoldenSolution.DAL.Models;

namespace GoldenSolution.Core.Mappers.UserMappers;

public interface ICareerMapper
{
	public List<CareerDto> Map(List<Career> careers);
}
