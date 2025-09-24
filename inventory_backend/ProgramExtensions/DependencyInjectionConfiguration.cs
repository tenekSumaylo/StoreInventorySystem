using inventory_backend.Authentication;
using inventory_backend.Authentication.BasicAuthentication;
using inventory_backend.Dtos;
using inventory_backend.TokenServices;

namespace inventory_backend.ProgramExtensions
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService<LoginDto, RegisterDto>, BasicAuthenticationService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
