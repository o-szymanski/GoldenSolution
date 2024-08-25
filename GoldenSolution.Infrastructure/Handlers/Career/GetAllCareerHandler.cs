using GoldenSolution.Core.Entities.DTO.Career;
using GoldenSolution.Core.Functions.Queries.Career;
using GoldenSolution.Core.Mappers.UserMappers;
using GoldenSolution.Infrastructure.Services.CareerService;
using MediatR;

namespace GoldenSolution.Infrastructure.Handlers.Career;

public class GetAllCareerHandler : IRequestHandler<GetAllCareerQuery, List<CareerDto>?>
{
    private readonly ICareerService _careersService;
    private readonly ICareerMapper _careerMapper;

    public GetAllCareerHandler(ICareerService careersService, ICareerMapper careerMapper)
    {
        _careersService = careersService;
        _careerMapper = careerMapper;
    }

    public async Task<List<CareerDto>?> Handle(GetAllCareerQuery request, CancellationToken cancellationToken)
    {
        var careers = await _careersService.GetAllCareersAsync();
        return careers.Count is 0 ? null : _careerMapper.Map(careers);
    }
}
