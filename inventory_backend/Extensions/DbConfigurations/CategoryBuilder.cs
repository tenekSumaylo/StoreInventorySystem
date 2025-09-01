using inventory_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class CategoryBuilder
    {
        public static void Configure( this EntityTypeBuilder<Category> category)
        {
            category.Property(i => i.Id).ValueGeneratedOnAdd();
            category.HasMany(i => i.Products).WithOne(d => d.Category).HasForeignKey(i => i.CategoryId);
            category.Property(i => i.Name).HasDefaultValue("N/A").HasMaxLength(100).IsRequired();
        }
    }
}
