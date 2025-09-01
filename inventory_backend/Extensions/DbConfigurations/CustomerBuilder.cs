using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using inventory_backend.Models;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class CustomerBuilder
    {
        public static void Configure( this EntityTypeBuilder<Customer> modelBuilder )
        {
            modelBuilder.HasKey(i => i.Id);
            modelBuilder.HasMany(i => i.Invoices).WithOne(i => i.Customer).HasForeignKey(i => i.CustomerId);
            modelBuilder.Property(i => i.Email).IsRequired();
            modelBuilder.HasIndex(i => i.Email);
            modelBuilder.HasIndex(i => i.Id);
            modelBuilder.HasIndex(i => i.FirstName);
        }
    }
}
