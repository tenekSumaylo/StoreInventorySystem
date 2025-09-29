using inventory_backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class ShoppingCartItemBuilder
    {
        public static void Configure( this EntityTypeBuilder<ShoppingCartItem> modelBuilder )
        {
            modelBuilder.HasKey( x => x.Id );
            modelBuilder.HasOne(x => x.Product).WithMany(b => b.CartItems).HasForeignKey(x => x.ProductId);
        }
    }
}
