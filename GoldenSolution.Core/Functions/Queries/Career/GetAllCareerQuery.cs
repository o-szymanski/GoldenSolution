using GoldenSolution.Core.Models.DTO.Career;
using MediatR;

namespace GoldenSolution.Core.Functions.Queries.Career;

public record GetAllCareerQuery : IRequest<List<CareerDto>>;
