using inventory_backend.Exceptions;
using inventory_backend.Models.Users;
using inventory_backend.TokenServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Security.Claims;

namespace inventory_backend.Authentication.GoogleAuthentication
{
    public class GoogleAuthenticationService(UserManager<ApplicationUser> manager, 
        SignInManager<ApplicationUser> service, ITokenService tokenService) : IGoogleAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _manager = manager;
        private readonly SignInManager<ApplicationUser> _signinManager = service;
        private readonly ITokenService _tokenService = tokenService;

        // this section is to be implemented
        public async Task<IdentityResult> CreateUser(ExternalLoginInfo data)
        {
            var emailResult = await _manager.FindByEmailAsync(data.Principal.FindFirstValue(ClaimTypes.Email)!);
            if ( emailResult is not null )
            {
                return IdentityResult.Failed( new IdentityError
                {
                    Code = "User already exists",
                    Description = "User registration cannot proceed...."
                });
            }
            var user = new Customer
            {
                FirstName = data.Principal.FindFirstValue(ClaimTypes.GivenName) ?? throw new RegisterException("First name is null"),
                LastName = data.Principal.FindFirstValue(ClaimTypes.Surname) ?? throw new RegisterException("Last name is null..."),
                Email = data.Principal.FindFirstValue(ClaimTypes.Email) ?? throw new RegisterException("Email is invalid"),
                UserName = data.Principal.FindFirstValue(ClaimTypes.Email)
            };
            var createAsync = await _manager.CreateAsync(user);
            var result = await _manager.AddLoginAsync(user, data);
            return result.Succeeded && createAsync.Succeeded ? result : throw new RegisterException("Registration failed", result);
        }

        public async Task<string?> Login(Microsoft.AspNetCore.Authentication.AuthenticateResult data)
        {
            if ( data.Succeeded)
            {
                var info = await _signinManager.GetExternalLoginInfoAsync() ?? throw new LoginException();
                var result = await _manager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if ( result is not null )
                {
                    var roles = await _manager.GetRolesAsync(result);
                    return _tokenService.GenerateToken(result, roles);
                }

            }
            throw new LoginException("Authentication failed", data.Failure ?? throw new Exception());
        }

        public AuthenticationProperties ConfigureExternal(string provider, string redirectUrl) =>
            _signinManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

        public async Task<ExternalLoginInfo?> GetExternalInformation() => await _signinManager.GetExternalLoginInfoAsync();

        public Task<IdentityResult> CreateAdmin(ExternalLoginInfo data)
        {
            throw new NotImplementedException();
        }
    }
}
