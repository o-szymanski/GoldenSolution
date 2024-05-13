using GoldenSolution.Core.DAL;
using GoldenSolution.Core.DTO.Authentication;
using GoldenSolution.Core.Function.Query;
using GoldenSolution.Core.Mappers.AuthenticationMappers;
using GoldenSolution.DAL.Models;
using MediatR;

namespace GoldenSolution.Infrastructure.Handlers;

public class GetUserNameHandler : IRequestHandler<GetUserNameQuery, UserDto>
{
	private readonly IRepository<User> repository;

	public GetUserNameHandler(IRepository<User> repository)
	{
		this.repository = repository;
	}

	public async Task<UserDto> Handle(GetUserNameQuery request, CancellationToken cancellationToken)
	{
		var user = await repository.GetById(request.Id);
		return user == null ? new UserDto { Id = 0 } : UserMap.ToUserDto(user);
	}
}
