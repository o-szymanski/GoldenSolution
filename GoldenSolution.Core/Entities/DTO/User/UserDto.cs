namespace GoldenSolution.Core.Entities.DTO.User;

public record UserDto(string Id, string UserName, string? NormalizedUserName, string Email, string NormalizedEmail, bool EmailConfirmed, string? PasswordHash, string? SecurityStamp, string? ConcurrencyStamp, string PhoneNumber, bool PhoneNumberConfirmed, bool TwoFactorEnabled, DateTimeOffset? LockoutEnd, bool LockoutEnabled, int AccessFailedCount);