using inventory_backend.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace inventory_backend.Services.AuthServices
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto dto);
        Task<IdentityResult> Register(RegisterDto dto);
        AuthenticationProperties ConfigureExternalLogin(string provider, string? redirectUrl);
        Task<ExternalLoginInfo?> GetExternalLoginInfoAsync();
        Task<Microsoft.AspNetCore.Identity.SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
        Task<IdentityResult> CreateExternalUserAsync(ExternalLoginInfo info);

    }
}
