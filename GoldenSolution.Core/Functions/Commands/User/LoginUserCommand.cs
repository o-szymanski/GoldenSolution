using GoldenSolution.Core.Output.User;
using MediatR;

namespace GoldenSolution.Core.Functions.Commands.User;

public record LoginUserCommand(string Email, string Password) : IRequest<LoginUserResponse?>;
