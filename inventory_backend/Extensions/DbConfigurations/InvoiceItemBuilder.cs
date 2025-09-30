using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using inventory_backend.Models;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class InvoiceItemBuilder
    {
        public static void Configure( this EntityTypeBuilder<InvoiceItem> modelBuilder )
        {
            modelBuilder.HasKey( x => x.Id );
            modelBuilder.Property(i => i.Quantity).HasDefaultValue(0).IsRequired();
        }
    }
}
