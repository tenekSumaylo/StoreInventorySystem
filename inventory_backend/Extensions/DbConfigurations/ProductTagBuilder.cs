using inventory_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class ProductTagBuilder
    {
        public static void Configure( this EntityTypeBuilder<ProductTag> builder )
        {
            builder.HasKey(i => i.Id);
            builder.HasIndex(i => i.Id);
            builder.Property(i => i.Tag).HasDefaultValue("N/a").IsRequired();
        }
    }
}
