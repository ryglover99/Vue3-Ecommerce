using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace glovers_backstore.Migrations
{
    /// <inheritdoc />
    public partial class CleanedUpModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderProductDetails");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderProductDetails",
                newName: "IX_OrderProductDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderProductDetails",
                newName: "IX_OrderProductDetails_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductDetails",
                table: "OrderProductDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductDetails_Orders_OrderId",
                table: "OrderProductDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductDetails_Products_ProductId",
                table: "OrderProductDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductDetails_Orders_OrderId",
                table: "OrderProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductDetails_Products_ProductId",
                table: "OrderProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductDetails",
                table: "OrderProductDetails");

            migrationBuilder.RenameTable(
                name: "OrderProductDetails",
                newName: "OrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductDetails_ProductId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductDetails_OrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
