using Microsoft.AspNetCore.Identity;

namespace inventory_backend.Authentication
{
    public interface IAuthenticationService<TLogin, TCreate> 
        where TLogin : class
        where TCreate : class
    {
        Task<string?> Login(TLogin data);
        Task<IdentityResult> CreateUser(TCreate data);
    }
}
