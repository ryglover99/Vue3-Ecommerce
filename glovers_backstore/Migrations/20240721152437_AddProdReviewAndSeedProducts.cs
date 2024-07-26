using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace glovers_backstore.Migrations
{
    /// <inheritdoc />
    public partial class AddProdReviewAndSeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Image", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Fruit", "Fresh red apple", "pink_apple.jpg", 0.99m, "Apple" },
                    { 2, "Fruit", "Ripe yellow banana", "bannana.jpg", 0.59m, "Banana" },
                    { 3, "Fruit", "Juicy orange", "orange.jpg", 1.19m, "Orange" },
                    { 4, "Vegetable", "Fresh green broccoli", "brocolli.jpg", 1.79m, "Broccoli" },
                    { 5, "Vegetable", "Crunchy orange carrot", "carrot.jpg", 0.89m, "Fresh Carrots" },
                    { 6, "Vegetable", "Red ripe tomato", "tomato.jpg", 1.49m, "Pack of 3 Tomatos" },
                    { 7, "Vegetable", "Starchy brown potato", "potato.jpg", 0.99m, "Baking Potatos" },
                    { 8, "Bakery", "Whole wheat bread", "bread.jpg", 2.49m, "Bread" },
                    { 9, "Dairy", "Fresh whole milk", "milk.jpg", 1.49m, "Whole Milk" },
                    { 10, "Dairy", "Cheddar cheese block", "cheese.jpg", 3.99m, "Cheddar Cheese" },
                    { 11, "Dairy", "Plain Greek yogurt", "yoghurt.jpg", 0.99m, "Greek Yogurt" },
                    { 12, "Meat", "Boneless skinless chicken breast", "chicken-breast.jpg", 4.99m, "Chicken Breast" },
                    { 13, "Meat", "Juicy beef steak", "beef-steak.jpg", 9.99m, "Beef Steak" },
                    { 14, "Seafood", "Fresh salmon fillet", "salmon-fillet.jpg", 12.99m, "Salmon Fillet" },
                    { 15, "Seafood", "Frozen peeled shrimp", "shrimp.jpg", 14.99m, "Frozen Shrimp" },
                    { 16, "Grain", "Whole grain pasta", "pasta.jpg", 1.29m, "Pene Pasta" },
                    { 17, "Grain", "Long grain rice", "rice.jpg", 1.09m, "White Rice" },
                    { 18, "Grain", "Rolled oats", "oats.jpg", 2.49m, "Kirkland Oats" },
                    { 19, "Nuts", "Raw whole almonds", "almonds.jpg", 5.99m, "Kirkland Almonds" },
                    { 20, "Spreads", "Creamy peanut butter", "peanut-butter.jpg", 3.49m, "Jif Peanut Butter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
