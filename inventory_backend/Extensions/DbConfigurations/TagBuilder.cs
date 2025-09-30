using inventory_backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class TagBuilder
    {
        public static void Configure(this EntityTypeBuilder<Tags> modelBuilder)
        {
            modelBuilder.HasKey(i => i.Id);
            modelBuilder.Property(i => i.Tag).IsRequired();
        }
    }
}
