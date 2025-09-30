using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inventory_backend.Migrations
{
    /// <inheritdoc />
    public partial class JunctionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Products_Id",
                table: "ProductTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags");

            migrationBuilder.DropIndex(
                name: "IX_ProductTags_Id",
                table: "ProductTags");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "ProductTags");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductTags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags",
                columns: new[] { "Id", "ProductId" });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_Id_ProductId",
                table: "ProductTags",
                columns: new[] { "Id", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_ProductId",
                table: "ProductTags",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Products_ProductId",
                table: "ProductTags",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Tags_Id",
                table: "ProductTags",
                column: "Id",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Products_ProductId",
                table: "ProductTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Tags_Id",
                table: "ProductTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags");

            migrationBuilder.DropIndex(
                name: "IX_ProductTags_Id_ProductId",
                table: "ProductTags");

            migrationBuilder.DropIndex(
                name: "IX_ProductTags_ProductId",
                table: "ProductTags");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductTags");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "ProductTags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "N/a");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_Id",
                table: "ProductTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Products_Id",
                table: "ProductTags",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
