using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Scheduler.Core.Interfaces;

namespace Scheduler.Core.Services;

public class TokenService : ITokenService
{
	private readonly string _jwtSecret;
	private readonly string _issuer;
	private readonly string _audience;

	public TokenService(string jwtSecret, string issuer, string audience)
	{
		_jwtSecret = jwtSecret;
		_issuer = issuer;
		_audience = audience;
	}

	public string GenerateToken(Guid userId, string email)
	{
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
			new Claim(JwtRegisteredClaimNames.Email, email)
		};

		var token = new JwtSecurityToken(
			issuer: _issuer,
			audience: _audience,
			claims: claims,
			expires: DateTime.UtcNow.AddDays(7),
			signingCredentials: creds
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}