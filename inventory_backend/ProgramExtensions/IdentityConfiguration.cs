using inventory_backend.Data;
using inventory_backend.Models;
using Microsoft.AspNetCore.Identity;

namespace inventory_backend.ProgramExtensions
{
    public static class IdentityConfiguration
    {
        public static void ConfigureIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentityCore<Customer>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 12;
            }).AddEntityFrameworkStores<IdentityDbContext>().AddDefaultTokenProviders().AddSignInManager<SignInManager<Customer>>();
        }
    }
}
