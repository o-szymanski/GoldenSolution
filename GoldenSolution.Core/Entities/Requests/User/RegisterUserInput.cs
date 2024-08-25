namespace GoldenSolution.Core.Entities.Requests.User;

public record RegisterUserInput(string Email, string Password, string RepeatPassword);
