using GoldenSolution.Core.DTO.Career;
using GoldenSolution.DAL.Models;
using Riok.Mapperly.Abstractions;

namespace GoldenSolution.Core.Mappers.CareerMappers;

[Mapper]
public partial class CareerMapper
{
	public partial List<CareerDto> Map(List<Career> careers);
}
