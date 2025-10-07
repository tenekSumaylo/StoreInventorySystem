using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inventory_backend.Migrations
{
    /// <inheritdoc />
    public partial class NewNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Order_OrderId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Order_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Products_ProductId",
                table: "ShoppingCartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItem",
                table: "ShoppingCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItem",
                newName: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItem_ProductId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_CustomerId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Products_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartItems",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Products_ProductId",
                table: "ShoppingCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItems",
                newName: "ShoppingCartItem");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_CustomerId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId",
                table: "ShoppingCartItem",
                newName: "IX_ShoppingCartItem_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItem",
                newName: "IX_ShoppingCartItem_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItem",
                table: "ShoppingCartItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Order_OrderId",
                table: "Invoices",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Order_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_Products_ProductId",
                table: "ShoppingCartItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
