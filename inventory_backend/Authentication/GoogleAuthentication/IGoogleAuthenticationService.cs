using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace inventory_backend.Authentication.GoogleAuthentication
{
    public interface IGoogleAuthenticationService : IAuthenticationService<Microsoft.AspNetCore.Authentication.AuthenticateResult, ExternalLoginInfo>
    {
        Task<ExternalLoginInfo?> GetExternalInformation();
        AuthenticationProperties ConfigureExternal(string provider, string redirectUrl);
    }
}
