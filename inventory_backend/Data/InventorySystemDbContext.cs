using inventory_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Data
{
    public class InventorySystemDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers {get; set; }
        public InventorySystemDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
