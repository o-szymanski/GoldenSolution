namespace GoldenSolution.Core.Entities.Requests.User;

public record RegisterUserRequest(string Email, string Password, string RepeatPassword);
