using inventory_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.ProgramExtensions
{
    public static class DbContextConfiguration
    {
        public static void ConfigureDbContext(this WebApplicationBuilder builder )
        {
            builder.Services.AddDbContext<InventorySystemDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });
        }
    }
}
