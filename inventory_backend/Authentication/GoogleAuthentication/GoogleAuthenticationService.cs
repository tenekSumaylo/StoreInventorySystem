using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace inventory_backend.Authentication.GoogleAuthentication
{
    public class GoogleAuthenticationService : IAuthenticationService<AuthenticateResult, ExternalLoginInfo>
    {
        // this section is to be implemented
        public Task<IdentityResult> CreateUser(ExternalLoginInfo data)
        {
            throw new NotImplementedException();
        }

        public Task<string?> Login(AuthenticateResult data)
        {
            throw new NotImplementedException();
        }
    }
}
