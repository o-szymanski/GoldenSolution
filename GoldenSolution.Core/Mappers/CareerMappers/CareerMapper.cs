using GoldenSolution.Core.Mappers.UserMappers;
using GoldenSolution.Core.Models.DTO.Career;
using GoldenSolution.DAL.Models;
using Riok.Mapperly.Abstractions;

namespace GoldenSolution.Core.Mappers.CareerMappers;

[Mapper]
public partial class CareerMapper : ICareerMapper
{
	public partial List<CareerDto> Map(List<Career> careers);
}
