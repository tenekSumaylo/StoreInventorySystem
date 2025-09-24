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
            modelBuilder.Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Property(i => i.Email).IsRequired();
            modelBuilder.HasIndex(i => i.Email).IsUnique();
            modelBuilder.HasIndex(i => i.Id).IsUnique();
            modelBuilder.HasIndex(i => i.UserName);
        }
    }
}
