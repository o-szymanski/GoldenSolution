using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GoldenSolution.Core.Functions.Commands.User;

public record RegisterUserCommand(string Email, string Password) : IRequest<IdentityResult>;
