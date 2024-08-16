using GoldenSolution.Core.DTO.User;
using MediatR;

namespace GoldenSolution.Core.Functions.Queries.User;

public record GetUserDataByIdQuery(string Id) : IRequest<UserDto>;
