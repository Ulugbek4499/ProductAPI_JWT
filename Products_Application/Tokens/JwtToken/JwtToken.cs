using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Products_Application.Interfaces.TokenInterfaces;
using Products_Domain.Models.Tokens;
using Products_Domain.Models.Users;

namespace Products_Application.Tokens.TokenServices
{
    public class JwtToken : IJwtToken
    {
        private readonly TokenConfiguration _tokenConfiguration;
        public JwtToken(IConfiguration configuration)
        {
            _tokenConfiguration = new TokenConfiguration();
            configuration.Bind("Jwt", _tokenConfiguration);
        }
        public string GenerateJwtToken(User user)
        {
            byte[] convertKeyToBytes =
             Encoding.UTF8.GetBytes(_tokenConfiguration.Key);

            var securityKey =
              new SymmetricSecurityKey(convertKeyToBytes);

            var credentials =
              new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim("UserName", user.Username),
                new Claim("Password", user.Password),
                new Claim(ClaimTypes.Role, "get_all_users")
            };

            var token = new JwtSecurityToken(
              issuer: _tokenConfiguration.Issue,
              audience: _tokenConfiguration.Audience,
              claims: claims,
              expires: DateTime.UtcNow.AddDays(1),
              signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string HashToken(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
