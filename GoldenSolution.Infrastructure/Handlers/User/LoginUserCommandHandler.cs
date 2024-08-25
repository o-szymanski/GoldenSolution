using GoldenSolution.Core.Entities.Responses.User;
using GoldenSolution.Core.Functions.Commands.User;
using GoldenSolution.Infrastructure.Services.UserService;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace GoldenSolution.Infrastructure.Handlers.User;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse?>
{
	private readonly IConfiguration _configuration;
	private readonly IUserService _userService;

	public LoginUserCommandHandler(IConfiguration configuration, IUserService userService)
	{
		_configuration = configuration;
		_userService = userService;
	}

	public async Task<LoginUserResponse?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
	{
		return await _userService.LoginUserAsync(request.Email, request.Password, _configuration["JWT:Key"] ?? string.Empty, _configuration["JWT:Issuer"] ?? string.Empty);
	}
}
