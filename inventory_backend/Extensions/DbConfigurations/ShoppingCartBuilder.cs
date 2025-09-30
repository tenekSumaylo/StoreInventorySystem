using inventory_backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static  class ShoppingCartBuilder
    {
        public static void Configure( this EntityTypeBuilder<ShoppingCart> modelBuilder )
        {
            modelBuilder.HasKey( x => x.Id );
            modelBuilder.HasMany(i => i.CartItems).WithOne(x => x.Cart).HasForeignKey(f => f.ShoppingCartId);
            modelBuilder.Property(b => b.CustomerId).IsRequired();
        }
    }
}
