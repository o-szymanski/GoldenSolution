using GoldenSolution.Core.DAL;
using GoldenSolution.Core.DTO.User;
using GoldenSolution.Core.Function.Query;
using GoldenSolution.Core.Mappers.UserMappers;
using GoldenSolution.DAL.Models;
using MediatR;

namespace GoldenSolution.Infrastructure.Handlers;

public class GetUserNameHandler : IRequestHandler<GetUserNameQuery, UserDto>
{
	private readonly IRepository<User> _repository;
	private readonly UserMapper _userMapper;

	public GetUserNameHandler(IRepository<User> repository, UserMapper userMapper)
	{
		_repository = repository;
		_userMapper = userMapper;
	}

	public async Task<UserDto> Handle(GetUserNameQuery request, CancellationToken cancellationToken)
	{
		var user = await _repository.GetById(request.Id);
		return user is null ? new(0, string.Empty) : _userMapper.Map(user);
	}
}
