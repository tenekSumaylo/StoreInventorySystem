using inventory_backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class InvoiceBuilder
    {
        public static void Configure( this EntityTypeBuilder<Invoice> modelBuilder )
        {

        }
    }
}
