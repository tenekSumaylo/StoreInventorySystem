using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using inventory_backend.Models;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class ProductBuilder
    {
        public static void Configure( this EntityTypeBuilder<Product> productBuilder)
        {
            productBuilder.HasIndex(i => i.ProductName);
            productBuilder.HasKey(i => i.Id);
            productBuilder.Property(i => i.Brand).HasDefaultValue("N/A").IsRequired();
            productBuilder.Property(i => i.Price).IsRequired();
            productBuilder.Property(i => i.Stock).HasDefaultValue(0).IsRequired();
            productBuilder.HasMany(i => i.Tags ).WithOne(i => i.Product ).HasForeignKey(i => i.Id);
        }
     }
}
