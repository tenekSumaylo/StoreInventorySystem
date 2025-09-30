using inventory_backend.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace inventory_backend.Extensions.DbConfigurations
{
    public static class EmployeeBuilder
    {
        public static void Configure( this EntityTypeBuilder<Employee> modelBuilder )
        {
            modelBuilder.ToTable("Employees");

        }

    }
}
