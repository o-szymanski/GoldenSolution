using GoldenSolution.Core.DTO.Career;
using GoldenSolution.Core.Functions.Queries.Career;
using GoldenSolution.Core.Mappers.CareerMappers;
using GoldenSolution.Infrastructure.Services.CareerService;
using MediatR;

namespace GoldenSolution.Infrastructure.Handlers;

public class GetAllCareerHandler : IRequestHandler<GetAllCareerQuery, List<CareerDto>>
{
	private readonly ICareerService _careersService;
	private readonly CareerMapper _careerMapper;

	public GetAllCareerHandler(ICareerService careersService, CareerMapper careerMapper)
	{
		_careersService = careersService;
		_careerMapper = careerMapper;
	}

	public async Task<List<CareerDto>> Handle(GetAllCareerQuery request, CancellationToken cancellationToken)
	{
		var careers = await _careersService.GetAllCareersAsync();
		return careers.Count <= 0 ? [] : _careerMapper.Map(careers);
	}
}
