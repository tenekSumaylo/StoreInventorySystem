using inventory_backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class OrderBuilder
    {
        public static void Configure(this EntityTypeBuilder<Order> modelBuilder )
        {
            modelBuilder.HasKey(i => i.Id);
            modelBuilder.Property(i => i.OrderDate).IsRequired();
            modelBuilder.HasMany(i => i.Items).WithOne(i => i.Order).HasForeignKey(b => b.OrderId); 
            modelBuilder.Property(i => i.CustomerId).IsRequired();
        }
    }
}
