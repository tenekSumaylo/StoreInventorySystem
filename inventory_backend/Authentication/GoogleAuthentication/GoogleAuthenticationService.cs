using inventory_backend.Exceptions;
using inventory_backend.Models;
using inventory_backend.TokenServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Security.Claims;

namespace inventory_backend.Authentication.GoogleAuthentication
{
    public class GoogleAuthenticationService(UserManager<Customer> manager, 
        SignInManager<Customer> service, ITokenService tokenService) : IAuthenticationService<AuthenticateResult, ExternalLoginInfo>
    {
        private readonly UserManager<Customer> _manager = manager;
        private readonly SignInManager<Customer> _signinManager = service;
        private readonly ITokenService _tokenService = tokenService;

        // this section is to be implemented
        public async Task<IdentityResult> CreateUser(ExternalLoginInfo data)
        {
            var user = new Customer
            {
                FirstName = data.Principal.FindFirstValue(ClaimTypes.GivenName) ?? throw new Exception("First name is null"),
                LastName = data.Principal.FindFirstValue(ClaimTypes.Surname) ?? throw new Exception("Last name is null..."),
                Email = data.Principal.FindFirstValue(ClaimTypes.Email)
            };
            var result = await _manager.AddLoginAsync(user, data);
            var createAsync = await _manager.CreateAsync(user);
            return result.Succeeded && createAsync.Succeeded ? result : throw new RegisterException("Registration failed", result);
        }

        public async Task<string?> Login(AuthenticateResult data)
        {
            if ( data.Succeeded)
            {
                var info = await _signinManager.GetExternalLoginInfoAsync() ?? throw new LoginException();
                var result = await _manager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if ( result is not null )
                {
                    return _tokenService.GenerateToken(result);
                }
                else
                {
                    var res = await CreateUser(info);
                    res.
                }

            }
            throw new LoginException("Authentication failed", data.Failure ?? throw new Exception());
        }

        public AuthenticationProperties ConfigureExternal(string provider, string redirectUrl) =>
            _signinManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

    }
}
