using inventory_backend.Dtos;
using inventory_backend.Exceptions;
using inventory_backend.Mapper.Extensions;
using inventory_backend.Models;
using Microsoft.AspNetCore.Authentication;
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
        private readonly SignInManager<Customer> _signInManager;
        public AuthService(UserManager<Customer> manager, IConfiguration config, SignInManager<Customer> signInManager)
        {
            _manager = manager;
            _configuration = config;
            _signInManager = signInManager;
        }
        public async Task<string> Login(LoginDto dto)
        {
            var userInformation = await _manager.FindByNameAsync(dto.UserLogin) ?? throw new LoginException("User not found");
            if (!await _manager.CheckPasswordAsync(userInformation, dto.Password)) throw new LoginException("Password incorrect");
            var generateToken = GenerateToken(userInformation);
            return generateToken;
        }

        public async Task<IdentityResult> Register(RegisterDto dto)
        {
            var registrationResult = await _manager.CreateAsync(dto.RegisterToCustomerEntity(), dto.Password);
            if (!registrationResult.Succeeded) throw new RegisterException("Registration unsuccessful", registrationResult);
            return registrationResult;
        }

        public AuthenticationProperties ConfigureExternalLogin(string provider, string? redirectUrl) => _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

        public async Task<ExternalLoginInfo?> GetExternalLoginInfoAsync() => await _signInManager.GetExternalLoginInfoAsync();

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent)
        {
            return await _signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent, bypassTwoFactor: true); 
        }

        public async Task<IdentityResult> CreateExternalUserAsync(ExternalLoginInfo info)
        {
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            if ( string.IsNullOrEmpty(email))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email not found" });
            }

            var existingUser = await _manager.FindByEmailAsync(email);
            if ( existingUser is null )
            {
                var loginResult = await _manager.AddLoginAsync(existingUser, info);
                if (loginResult.Succeeded)
                {
                    await _signInManager.SignInAsync(existingUser, isPersistent: false);
                }
                return loginResult;
            }

            var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? string.Empty;
            var lastname = info.Principal.FindFirstValue(ClaimTypes.Surname) ?? string.Empty;

            var customer = new Customer
            {
                Email = email,
                FirstName = firstName,
                LastName = lastname,
                EmailConfirmed = true
            };

            var result = await _manager.CreateAsync(customer);
            if ( !result.Succeeded)
            {
                return result;
            }

            result = await _manager.AddLoginAsync(customer, info);
            if (result.Succeeded )
            {
                await _signInManager.SignInAsync(customer, isPersistent: false);
            }
            return result;

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
