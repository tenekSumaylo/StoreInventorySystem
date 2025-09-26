using inventory_backend.Exceptions;
using inventory_backend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Security.Claims;

namespace inventory_backend.Authentication.GoogleAuthentication
{
    public class GoogleAuthenticationService(UserManager<Customer> manager) : IAuthenticationService<AuthenticateResult, ExternalLoginInfo>
    {
        private readonly UserManager<Customer> _manager = manager;

        // this section is to be implemented
        public async Task<IdentityResult> CreateUser(ExternalLoginInfo data)
        {
            var result = await _manager.AddLoginAsync(new Customer
            {
                FirstName = data.Principal.FindFirstValue(ClaimTypes.GivenName) ?? throw new Exception("First name is null"),
                LastName = data.Principal.FindFirstValue(ClaimTypes.Surname ) ?? throw new Exception("Last name is null..."),
                Email = data.Principal.FindFirstValue(ClaimTypes.Email)
            },data);
            return result.Succeeded ? result : throw new RegisterException("Registration failed", result);
        }

        public async Task<string?> Login(AuthenticateResult data)
        {
            if ( data.Succeeded)
            {

            }
            throw new LoginException("Authentication failed", data.Failure ?? throw new Exception());
        }

    }
}
