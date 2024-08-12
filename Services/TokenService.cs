using ClothingApi.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClothingApi.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(string key, string issuer, string audience, UserModel userModel)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, userModel.UserName),
                new Claim(ClaimTypes.NameIdentifier, userModel.Password,
                Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey security = new(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(security, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                claims: claims,
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(190),
                signingCredentials: credential);

            JwtSecurityTokenHandler tokenHandler = new();

            string StringToken = tokenHandler.WriteToken(token);

            return StringToken;
        }
    }
}
