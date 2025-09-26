using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace inventory_backend.ProgramExtensions
{
    public static class AuthenticationConfiguration
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                options.DefaultChallengeScheme =
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = "Identity.External";

            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie("Identity.External")
                .AddJwtBearer(options =>
            {
                var secret = config["JwtConfig:Secret"];
                var audience = config["JwtConfig:Audience"];
                var issuer = config["JwtConfig:Issuer"];

                if (secret is null || audience is null || issuer is null)
                {
                    throw new ApplicationException("Jwt has missing values");
                }
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidIssuer = issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                };
            })
            .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = config["Authentication:Google:ClientId"]!;
                googleOptions.ClientSecret = config["Authentication:Google:ClientSecret"]!;
                googleOptions.CallbackPath = "/signin-google";
                googleOptions.SignInScheme = IdentityConstants.ExternalScheme;

            });
        }
    }
}
