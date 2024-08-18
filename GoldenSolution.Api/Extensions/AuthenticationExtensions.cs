using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GoldenSolution.Api.Extensions;

public static class AuthenticationExtensions
{
	public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
	{
		var key = Encoding.ASCII.GetBytes(configuration["JWT:Key"] ?? string.Empty);

		services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(options =>
		{
			options.RequireHttpsMetadata = false;
			options.SaveToken = true;
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = false,
				ValidateIssuerSigningKey = true,
				ValidIssuer = configuration["JWT:Issuer" ?? string.Empty],
				IssuerSigningKey = new SymmetricSecurityKey(key)
			};
		});
	}
}
