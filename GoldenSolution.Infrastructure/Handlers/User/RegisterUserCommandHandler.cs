using GoldenSolution.Core.Functions.Commands.User;
using GoldenSolution.Infrastructure.Services.UserService;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GoldenSolution.Infrastructure.Handlers.User;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
{
	private readonly IUserService _userService;

	public RegisterUserCommandHandler(IUserService userService)
	{
		_userService = userService;
	}

	public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
	{
		return await _userService.RegisterUserAsync(request.Email, request.Password);
	}
}
