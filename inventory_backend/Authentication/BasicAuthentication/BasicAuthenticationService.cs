using AutoMapper;
using inventory_backend.Authentication;
using inventory_backend.Dtos;
using inventory_backend.Exceptions;
using inventory_backend.Extensions.RegisterDtoExtension;
using inventory_backend.Models.Users;
using inventory_backend.Roles;
using inventory_backend.Services.TokenServices;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace inventory_backend.Authentication.BasicAuthentication
{
    public class BasicAuthenticationService : IBasicAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public BasicAuthenticationService(UserManager<ApplicationUser> manager, ITokenService tokenService, IMapper mapper)
        {
            _manager = manager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateUser(RegisterDto data)
        {
            // map register dto to customer -- mock only -- AutoMapper to be added
            var mappedCustomer = _mapper.Map<Customer>(data);
            var result = await _manager.CreateAsync(mappedCustomer, data.Password);
            var roleResult = await _manager.AddToRoleAsync(mappedCustomer, AppRoles.Customer);
            if (result.Errors.FirstOrDefault() is not null || roleResult.Errors.FirstOrDefault() is not null)
            {
                throw new RegisterException("Faulted registration", result);
            }
            return result;
        }

        public async Task<IdentityResult> CreateAdmin(RegisterDto data)
        {
            var mappedEmployee = _mapper.Map<Employee>(data);
            var result = await _manager.CreateAsync(mappedEmployee, data.Password);
            var roleResult = await _manager.AddToRoleAsync(mappedEmployee, AppRoles.Employee);
            if (result.Errors.FirstOrDefault() is not null || roleResult.Errors.FirstOrDefault() is not null)
            {
                throw new RegisterException("Faulted registration", result);
            }
            return result;
        }

        public async Task<string?> Login(LoginDto data)
        {
            var username = await _manager.FindByNameAsync(data.UserLogin);
            if ( username is not null )
            {
                var resultUsername = await _manager.CheckPasswordAsync(username, data.Password);
                if (resultUsername)
                {
                    // token generate
                    var roles = await _manager.GetRolesAsync(username);
                    return _tokenService.GenerateToken(username, roles);
                }
            }

            var email = await _manager.FindByEmailAsync(data.UserLogin);
            if ( email  is not null )
            {
                var resultEmail = await _manager.CheckPasswordAsync(email, data.Password);
                if (resultEmail)
                {
                    var roles = await _manager.GetRolesAsync(email);
                    return _tokenService.GenerateToken(email, roles);
                }
            }
            throw new LoginException("Login credentials invalid...");
        }
    }
}
