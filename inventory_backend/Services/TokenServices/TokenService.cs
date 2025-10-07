using inventory_backend.Models.Users;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace inventory_backend.Services.TokenServices
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration) => _configuration = configuration;
        public string? GenerateToken(ApplicationUser user, IList<string>? roles)
        {
            var secret = _configuration["JwtConfig:Secret"];
            var issuer = _configuration["JwtConfig:Issuer"];
            var audiences = _configuration["JwtConfig:Audience"];

            if (secret is null || issuer is null || audiences is null)
            {
                throw new ApplicationException("Jwt is not configured properly");
            }
            var claims = new List<Claim> {

                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            foreach ( var role in roles! )
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = issuer,
                Audience = audiences,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
