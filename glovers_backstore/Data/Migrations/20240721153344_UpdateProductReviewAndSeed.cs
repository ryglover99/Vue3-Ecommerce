using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace glovers_backstore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductReviewAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ProductReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "Description", "ProductId", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "The apple was very fresh and juicy, with a perfect balance of sweetness and tartness.", 1, 5, "Delicious and Fresh" },
                    { 2, "Really enjoyed the crispiness and taste, but it could have been a bit sweeter.", 1, 4, "Great Apple" },
                    { 3, "It was okay, a bit too ripe for my taste, but still edible.", 2, 3, "Average Banana" },
                    { 4, "Just the right ripeness, sweet and tasty with no bruises.", 2, 5, "Perfectly Ripe" },
                    { 5, "Nice and juicy, good flavor, but had a few seeds.", 3, 4, "Juicy Orange" },
                    { 6, "Very sweet and fresh, loved it. Perfect for snacking.", 3, 5, "Excellent Orange" },
                    { 7, "Crisp and fresh, perfect for my stir fry. Stayed green and vibrant after cooking.", 4, 5, "Fresh Broccoli" },
                    { 8, "Good quality, stayed fresh for a while, but some florets were a bit small.", 4, 4, "Good Quality" },
                    { 9, "Very crunchy and sweet, great for snacking and salads.", 5, 4, "Crunchy Carrots" },
                    { 10, "Not the best, but still okay. A few were a bit limp.", 5, 3, "Decent Carrots" },
                    { 11, "Perfectly ripe and juicy tomatoes, ideal for sandwiches and salads.", 6, 5, "Ripe Tomatoes" },
                    { 12, "Nice pack of tomatoes, good for salads, but a couple were a bit soft.", 6, 4, "Good Pack" },
                    { 13, "Good for baking and mashing, with a nice fluffy texture when cooked.", 7, 4, "Starchy Potatoes" },
                    { 14, "Some were a bit small, but overall okay for general use.", 7, 3, "Average Potatoes" },
                    { 15, "Tasty and healthy, loved the texture and flavor, perfect for sandwiches.", 8, 5, "Whole Wheat Bread" },
                    { 16, "Fresh and soft, very good quality, but could use a bit more fiber.", 8, 4, "Good Bread" },
                    { 17, "Tastes fresh and creamy, perfect for cereals and drinking straight.", 9, 5, "Fresh Milk" },
                    { 18, "Nice fresh milk, kids loved it, but a bit pricey.", 9, 4, "Good Milk" },
                    { 19, "Rich and creamy, great for sandwiches and snacking, with a sharp flavor.", 10, 5, "Cheddar Cheese" },
                    { 20, "Nice flavor and texture, good for snacks and cooking.", 10, 4, "Good Cheese" },
                    { 21, "Thick and creamy, perfect for breakfast with honey and nuts.", 11, 4, "Greek Yogurt" },
                    { 22, "Loved the texture and taste, very fresh and tangy.", 11, 5, "Excellent Yogurt" },
                    { 23, "Very juicy and tender, great for grilling and stir-fries.", 12, 5, "Juicy Chicken Breast" },
                    { 24, "Good quality, cooked up nicely, but a bit on the expensive side.", 12, 4, "Good Chicken" },
                    { 25, "Excellent steak, very juicy and flavorful, perfect for grilling.", 13, 5, "Juicy Beef Steak" },
                    { 26, "Nice flavor, cooked up well, but slightly tough in some parts.", 13, 4, "Good Steak" },
                    { 27, "Very fresh and flavorful, great for grilling or baking.", 14, 5, "Fresh Salmon Fillet" },
                    { 28, "Nice fillet, good taste, but a bit pricey.", 14, 4, "Good Salmon" },
                    { 29, "Tasty and convenient, easy to cook and perfect for pasta dishes.", 15, 5, "Frozen Shrimp" },
                    { 30, "Nice flavor, good quality, but a bit too many small ones.", 15, 4, "Good Shrimp" },
                    { 31, "Good texture and taste, healthy option for pasta dishes.", 16, 4, "Whole Grain Pasta" },
                    { 32, "Not bad, but I prefer other brands for a more robust flavor.", 16, 3, "Decent Pasta" },
                    { 33, "Cooks up nicely, good quality rice, perfect for pilafs and side dishes.", 17, 5, "Long Grain Rice" },
                    { 34, "Nice texture, cooked evenly, but a bit sticky.", 17, 4, "Good Rice" },
                    { 35, "Perfect for breakfast, very fresh and great for overnight oats.", 18, 5, "Rolled Oats" },
                    { 36, "Nice quality, good for overnight oats and baking.", 18, 4, "Good Oats" },
                    { 37, "Crunchy and fresh, perfect snack, and great for adding to salads.", 19, 5, "Raw Almonds" },
                    { 38, "Nice flavor, good quality, but a few were a bit bitter.", 19, 4, "Good Almonds" },
                    { 39, "Rich and creamy, perfect for sandwiches and baking. Great taste.", 20, 5, "Creamy Peanut Butter" },
                    { 40, "Nice and smooth, great for spreading, but a bit too sweet for my liking.", 20, 4, "Tasty Peanut Butter" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ProductReviews");
        }
    }
}
