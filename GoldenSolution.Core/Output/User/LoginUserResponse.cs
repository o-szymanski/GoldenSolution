namespace GoldenSolution.Core.Output.User;
public class LoginUserResponse
{
	public string AccessToken { get; set; } = string.Empty;
	public string TokenType { get; set; } = string.Empty;
	public int ExpiresIn { get; set; }
	public string RefreshToken { get; set; } = string.Empty;
}
