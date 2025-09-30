using inventory_backend.Extensions.DbConfigurations;
using inventory_backend.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace inventory_backend.Data
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) 
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().UseTpcMappingStrategy();
            builder.Entity<ApplicationUser>().ToTable((string)null!);
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Employee>().ToTable("Employees");
        }
    }
}
