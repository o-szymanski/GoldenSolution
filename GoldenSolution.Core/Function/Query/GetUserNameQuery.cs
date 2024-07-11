using GoldenSolution.Core.DTO.User;
using MediatR;

namespace GoldenSolution.Core.Function.Query;

public record GetUserNameQuery(int Id) : IRequest<UserDto>;
