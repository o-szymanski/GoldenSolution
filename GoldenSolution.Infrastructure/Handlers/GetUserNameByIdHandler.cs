using GoldenSolution.Core.DTO.User;
using GoldenSolution.Core.Functions.Queries.User;
using GoldenSolution.Core.Mappers.UserMappers;
using GoldenSolution.Infrastructure.Services.UserService;
using MediatR;

namespace GoldenSolution.Infrastructure.Handlers;

public class GetUserNameByIdHandler : IRequestHandler<GetUserNameByIdQuery, UserDto>
{
	private readonly IUserService _userService;
	private readonly IUserMapper _userMapper;

	public GetUserNameByIdHandler(IUserService userService, IUserMapper userMapper)
	{
		_userService = userService;
		_userMapper = userMapper;
	}

	public async Task<UserDto> Handle(GetUserNameByIdQuery request, CancellationToken cancellationToken)
	{
		var user = await _userService.GetUserByIdAsync(request.Id);
		return user is null ? new(0, string.Empty) : _userMapper.Map(user);
	}
}
