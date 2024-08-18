using GoldenSolution.Core.DTO.User;
using GoldenSolution.Core.Functions.Queries.User;
using GoldenSolution.Core.Mappers.UserMappers;
using GoldenSolution.Infrastructure.Services.UserService;
using MediatR;

namespace GoldenSolution.Infrastructure.Handlers.User;

public class GetUserDataByIdHandler : IRequestHandler<GetUserDataByIdQuery, UserDto?>
{
    private readonly IUserService _userService;
    private readonly IUserMapper _userMapper;

    public GetUserDataByIdHandler(IUserService userService, IUserMapper userMapper)
    {
        _userService = userService;
        _userMapper = userMapper;
    }

    public async Task<UserDto?> Handle(GetUserDataByIdQuery request, CancellationToken cancellationToken)
    {
        var applicationUser = await _userService.GetUserByIdAsync(request.Id);
        return applicationUser is null ? null : _userMapper.Map(applicationUser);
    }
}
