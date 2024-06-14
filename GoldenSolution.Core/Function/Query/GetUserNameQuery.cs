using GoldenSolution.Core.DTO.Authentication;
using MediatR;

namespace GoldenSolution.Core.Function.Query;

public class GetUserNameQuery : IRequest<UserDto>
{
	public int Id { get; set; }
}
