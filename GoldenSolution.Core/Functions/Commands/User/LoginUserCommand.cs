using GoldenSolution.Core.Models.Responses.User;
using MediatR;

namespace GoldenSolution.Core.Functions.Commands.User;

public record LoginUserCommand(string Email, string Password) : IRequest<LoginUserResponse?>;
