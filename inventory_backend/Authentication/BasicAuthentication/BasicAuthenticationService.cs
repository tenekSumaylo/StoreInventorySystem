using inventory_backend.Authentication;
using inventory_backend.Dtos;
using inventory_backend.Exceptions;
using inventory_backend.Extensions.RegisterDtoExtension;
using inventory_backend.Models;
using inventory_backend.Services.TokenService;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace inventory_backend.Authentication.BasicAuthentication
{
    public class BasicAuthenticationService : IAuthenticationService<LoginDto, RegisterDto>
    {
        private readonly UserManager<Customer> _manager;
        private readonly ITokenService _tokenService;

        public BasicAuthenticationService(UserManager<Customer> manager, ITokenService tokenService)
        {
            _manager = manager;
            _tokenService = tokenService;
        }


        public async Task<IdentityResult> CreateUser(RegisterDto data)
        {
            // map registerdto to customer -- mock only -- AutoMapper to be added
            var mappedCustomer = data.MapToCustomer();
            var result = await _manager.CreateAsync(mappedCustomer, data.Password);
            if (result.Errors.FirstOrDefault() is not null)
            {
                throw new RegisterException("Faulted registration", result);
            }
            return result;
        }

        public async Task<string?> Login(LoginDto data)
        {
            Customer? username = await _manager.FindByNameAsync(data.UserLogin);
            if ( username is not null )
            {
                var resultUsername = await _manager.CheckPasswordAsync(username, data.Password);
                if (resultUsername)
                {
                    // token generate
                    return _tokenService.GenerateToken(username);
                }
            }

            Customer? email = await _manager.FindByEmailAsync(data.UserLogin);
            if ( email  is not null )
            {
                var resultEmail = await _manager.CheckPasswordAsync(email, data.Password);
                if (resultEmail)
                {
                    return _tokenService.GenerateToken(email);
                }
            }
            // generate token here
            throw new LoginException("Login credentials invalid...");

        }
    }
}
