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
            builder.HasKey(i =>  new {i.Id, i.ProductId });
            builder.HasIndex(i => new {i.Id, i.ProductId});
            builder.HasOne(i => i.Tag).WithMany(b => b.ProductTags).HasForeignKey(b => b.Id);
            builder.HasOne(i => i.Product).WithMany(b => b.Tags).HasForeignKey(b => b.ProductId);
        }
    }
}
