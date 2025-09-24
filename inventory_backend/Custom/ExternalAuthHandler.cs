using Microsoft.AspNetCore.Authentication;
using Microsoft.Identity.Client;

namespace inventory_backend.Custom
{
    public class ExternalAuthHandler : IAuthenticationHandler
    {
        public AuthenticationScheme? Scheme { get; set; }
        public HttpContext? Context { get; set; }
        
        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            Scheme = scheme;
            Context = context;
            return Task.CompletedTask;
        }

        public Task<AuthenticateResult> AuthenticateAsync()
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            return Task.CompletedTask;
        }

        public Task ForbidAsync(AuthenticationProperties properties)
        {
            return Task.CompletedTask;
        }
    }
}
