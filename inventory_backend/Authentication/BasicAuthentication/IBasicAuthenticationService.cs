using inventory_backend.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace inventory_backend.Authentication.BasicAuthentication
{
    public interface IBasicAuthenticationService : IAuthenticationService<LoginDto, RegisterDto>
    {
        Task<IdentityResult> CreateAdmin(RegisterDto data);
    }
}
