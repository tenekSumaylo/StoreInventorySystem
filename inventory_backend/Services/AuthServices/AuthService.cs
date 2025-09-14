using inventory_backend.Dtos;
using inventory_backend.Exceptions;
using inventory_backend.Mapper.Extensions;
using inventory_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace inventory_backend.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Customer> _manager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<Customer> manager, IConfiguration config)
        {
            _manager = manager;
            _configuration = config;    
        }
        public async Task<string> Login(LoginDto dto)
        {
            var userInformation = await _manager.FindByNameAsync(dto.UserLogin) ?? throw new Exception("User not found");
            if (!await _manager.CheckPasswordAsync(userInformation, dto.Password)) throw new Exception("Password incorrect");
            var generateToken = GenerateToken(userInformation);
            return generateToken;
        }

        public async Task<IdentityResult> Register(RegisterDto dto)
        {
            var registrationResult = await _manager.CreateAsync(dto.RegisterToCustomerEntity(), dto.Password);
            if (!registrationResult.Succeeded) throw new RegisterException("Registration unsuccessful", registrationResult);
            return registrationResult;
        }

        private string GenerateToken(object dto)
        {
            var user = dto as Customer ?? throw new Exception("The object is not a Customer");

            var secret = _configuration["JwtConfig:Secret"];
            var issuer = _configuration["JwtConfig:Issuer"];
            var audience = _configuration["JwtConfig:Audience"];

            if (secret is null || issuer is null || audience is null) throw new Exception("Jwt config has issues... null references are present");

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
