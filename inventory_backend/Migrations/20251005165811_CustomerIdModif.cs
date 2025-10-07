using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inventory_backend.Migrations
{
    /// <inheritdoc />
    public partial class CustomerIdModif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerId",
                table: "ShoppingCart",
                column: "CustomerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_CustomerId",
                table: "ShoppingCart");
        }
    }
}
