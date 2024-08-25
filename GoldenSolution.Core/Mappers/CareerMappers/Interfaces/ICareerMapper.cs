using GoldenSolution.Core.Entities.DTO.Career;
using GoldenSolution.DAL.Models;

namespace GoldenSolution.Core.Mappers.UserMappers;

public interface ICareerMapper
{
	public List<CareerDto> Map(List<Career> careers);
}
