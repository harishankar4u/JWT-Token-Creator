
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtTokenCreator.Infrastructure
{
    public class JWTTokenService : IJWTTOKEN
    {
        public Task<string> CreateTokenAsync(string secretKey, string issuer, string audience)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var expiration = now.AddYears(3); // 3-year validity

            var claims = new[]
            {
        new Claim("umId", "f66ac003-7e22-4e57-804f-bfb35c4863cc"),
        new Claim("id", "google.System.User"), // it is variable and optional
        new Claim("role", "SUADM"), // this one is also variable and optional
        new Claim(JwtRegisteredClaimNames.Iss, issuer),
        new Claim(JwtRegisteredClaimNames.Iat, ((DateTimeOffset)now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
    };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience, // Set audience only here
                claims: claims,
                notBefore: now,
                expires: expiration,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(tokenString);
        }
    }
}
