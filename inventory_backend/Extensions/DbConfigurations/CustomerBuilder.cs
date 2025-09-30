using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using inventory_backend.Models.Users;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class CustomerBuilder
    {
        public static void Configure( this EntityTypeBuilder<Customer> modelBuilder )
        {
            modelBuilder.ToTable("Customers");
        }
    }
}
