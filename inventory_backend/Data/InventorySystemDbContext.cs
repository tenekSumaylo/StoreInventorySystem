using inventory_backend.Extensions.DbConfigurations;
using inventory_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Data
{
    public class InventorySystemDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public InventorySystemDbContext(DbContextOptions<InventorySystemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().Configure();
            builder.Entity<Invoice>().Configure();
            builder.Entity<ProductTag>().Configure();
            builder.Entity<Category>().Configure();
            builder.Entity<InvoiceItem>().Configure();
            builder.Entity<ShoppingCart>().Configure();
            builder.Entity<ShoppingCartItem>().Configure();
            builder.Entity<Order>().Configure();
            builder.Entity<OrderItems>().Configure();
            builder.Entity<Tags>().Configure();
        }
    }
}
