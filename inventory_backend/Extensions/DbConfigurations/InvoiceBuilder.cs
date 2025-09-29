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
            modelBuilder.HasMany(i => i.Items).WithOne(i => i.Invoice).HasForeignKey(i => i.InvoiceId);
            modelBuilder.HasIndex(i => i.CustomerId);
            modelBuilder.HasOne(i => i.Order).WithMany(b => b.Invoices).HasForeignKey(i => i.OrderId);
            modelBuilder.Property(i => i.CustomerId).IsRequired();
        }
    }
}
