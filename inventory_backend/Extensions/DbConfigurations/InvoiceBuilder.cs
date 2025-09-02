using inventory_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class InvoiceBuilder
    {
        public static void Configure( this EntityTypeBuilder<Invoice> modelBuilder )
        {
            modelBuilder.HasKey( x => x.Id );
            modelBuilder.HasMany(i => i.InvoiceItems).WithOne(i => i.Invoice).HasForeignKey(i => i.InvoiceId);
            modelBuilder.Property(i => i.Quantity).HasDefaultValue(0).IsRequired();
        }
    }
}
