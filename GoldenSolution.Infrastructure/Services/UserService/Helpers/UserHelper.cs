using GoldenSolution.DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GoldenSolution.Infrastructure.Services.UserService.Helpers;

public static class UserHelper
{
    public static string GenerateJwtToken(ApplicationUser applicationUser, string key, string issuer)
    {
        var jwtKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        var creds = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken
        (
            issuer: issuer,
            audience: issuer,
            claims: claims,
            expires: DateTime.Now.AddSeconds(3600),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
}
