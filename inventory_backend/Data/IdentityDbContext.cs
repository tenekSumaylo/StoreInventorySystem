using inventory_backend.Extensions.DbConfigurations;
using inventory_backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Data
{
    public class IdentityDbContext : IdentityDbContext<Customer>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) 
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().Configure();
            base.OnModelCreating(builder);
        }
    }
}
