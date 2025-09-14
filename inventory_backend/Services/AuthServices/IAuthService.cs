using inventory_backend.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace inventory_backend.Services.AuthServices
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto dto);
        Task<IdentityResult> Register(RegisterDto dto);
    }
}
