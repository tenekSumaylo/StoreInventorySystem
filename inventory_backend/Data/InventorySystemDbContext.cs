using inventory_backend.Extensions.DbConfigurations;
using inventory_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Data
{
    public class InventorySystemDbContext : IdentityDbContext<Customer, IdentityRole<int>, int>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers {get; set; }
        public DbSet<InvoiceItem> invoiceItems { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Category> Categories { get; set; }

        public InventorySystemDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().Configure();
            builder.Entity<Invoice>().Configure();
            //builder.Entity<Customer>().Configure();
            builder.Entity<ProductTag>().Configure();
            builder.Entity<Category>().Configure();
            builder.Entity<InvoiceItem>().Configure();
        }
    }
}
