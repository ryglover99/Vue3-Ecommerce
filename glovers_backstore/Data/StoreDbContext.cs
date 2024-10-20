using glovers_backstore.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace glovers_backstore.Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seed Initial Data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Apple", Price = 0.99m, Category = "Fruit", Description = "Fresh red apple", Image = "pink_apple.jpg", NutritionImage = "apple.svg" },
                new Product { Id = 2, Title = "Banana", Price = 0.59m, Category = "Fruit", Description = "Ripe yellow banana", Image = "bannana.jpg", NutritionImage = "banana.svg" },
                new Product { Id = 3, Title = "Orange", Price = 1.19m, Category = "Fruit", Description = "Juicy orange", Image = "orange.jpg", NutritionImage = "orange.svg" },
                new Product { Id = 4, Title = "Broccoli", Price = 1.79m, Category = "Vegetable", Description = "Fresh green broccoli", Image = "brocolli.jpg", NutritionImage = "brocolli.svg" },
                new Product { Id = 5, Title = "Fresh Carrots", Price = 0.89m, Category = "Vegetable", Description = "Crunchy orange carrot", Image = "carrot.jpg", NutritionImage = "carrots.svg" },
                new Product { Id = 6, Title = "Pack of 3 Tomatos", Price = 1.49m, Category = "Vegetable", Description = "Red ripe tomato", Image = "tomato.jpg", NutritionImage = "tomatos.svg" },
                new Product { Id = 7, Title = "Baking Potatos", Price = 0.99m, Category = "Vegetable", Description = "Starchy brown potato", Image = "potato.jpg", NutritionImage = "potatos.svg" },
                new Product { Id = 8, Title = "Bread", Price = 2.49m, Category = "Bakery", Description = "Whole wheat bread", Image = "bread.jpg", NutritionImage = "bread.svg" },
                new Product { Id = 9, Title = "Whole Milk", Price = 1.49m, Category = "Dairy", Description = "Fresh whole milk", Image = "milk.jpg", NutritionImage = "whole_milk.svg" },
                new Product { Id = 10, Title = "Cheddar Cheese", Price = 3.99m, Category = "Dairy", Description = "Cheddar cheese block", Image = "cheese.jpg", NutritionImage = "cheddar_cheese.svg" },
                new Product { Id = 11, Title = "Greek Yogurt", Price = 0.99m, Category = "Dairy", Description = "Plain Greek yogurt", Image = "yoghurt.jpg", NutritionImage = "greek_yogurt.svg" },
                new Product { Id = 12, Title = "Chicken Breast", Price = 4.99m, Category = "Meat", Description = "Boneless skinless chicken breast", Image = "chicken-breast.jpg", NutritionImage = "chicken_breast.svg" },
                new Product { Id = 13, Title = "Beef Steak", Price = 9.99m, Category = "Meat", Description = "Juicy beef steak", Image = "beef-steak.jpg", NutritionImage = "beef_steak.svg" },
                new Product { Id = 14, Title = "Salmon Fillet", Price = 12.99m, Category = "Seafood", Description = "Fresh salmon fillet", Image = "salmon-fillet.jpg", NutritionImage = "salmon_fillet.svg" },
                new Product { Id = 15, Title = "Frozen Shrimp", Price = 14.99m, Category = "Seafood", Description = "Frozen peeled shrimp", Image = "shrimp.jpg", NutritionImage = "frozen_shrimp.svg" },
                new Product { Id = 16, Title = "Pene Pasta", Price = 1.29m, Category = "Grain", Description = "Whole grain pasta", Image = "pasta.jpg", NutritionImage = "pene_pasta.svg" },
                new Product { Id = 17, Title = "White Rice", Price = 1.09m, Category = "Grain", Description = "Long grain rice", Image = "rice.jpg", NutritionImage = "white_rice.svg" },
                new Product { Id = 18, Title = "Kirkland Oats", Price = 2.49m, Category = "Grain", Description = "Rolled oats", Image = "oats.jpg", NutritionImage = "oats.svg" },
                new Product { Id = 19, Title = "Kirkland Almonds", Price = 5.99m, Category = "Nuts", Description = "Raw whole almonds", Image = "almonds.jpg", NutritionImage = "almonds.svg" },
                new Product { Id = 20, Title = "Jif Peanut Butter", Price = 3.49m, Category = "Spreads", Description = "Creamy peanut butter", Image = "peanut-butter.jpg", NutritionImage = "peanut_butter.svg" }
            );

            modelBuilder.Entity<ProductReview>().HasData(
                new ProductReview { Id = 1, ProductId = 1, Rating = 5, Title = "Delicious and Fresh", Description = "The apple was very fresh and juicy, with a perfect balance of sweetness and tartness." },
                new ProductReview { Id = 2, ProductId = 1, Rating = 4, Title = "Great Apple", Description = "Really enjoyed the crispiness and taste, but it could have been a bit sweeter." },
                new ProductReview { Id = 3, ProductId = 2, Rating = 3, Title = "Average Banana", Description = "It was okay, a bit too ripe for my taste, but still edible." },
                new ProductReview { Id = 4, ProductId = 2, Rating = 5, Title = "Perfectly Ripe", Description = "Just the right ripeness, sweet and tasty with no bruises." },
                new ProductReview { Id = 5, ProductId = 3, Rating = 4, Title = "Juicy Orange", Description = "Nice and juicy, good flavor, but had a few seeds." },
                new ProductReview { Id = 6, ProductId = 3, Rating = 5, Title = "Excellent Orange", Description = "Very sweet and fresh, loved it. Perfect for snacking." },
                new ProductReview { Id = 7, ProductId = 4, Rating = 5, Title = "Fresh Broccoli", Description = "Crisp and fresh, perfect for my stir fry. Stayed green and vibrant after cooking." },
                new ProductReview { Id = 8, ProductId = 4, Rating = 4, Title = "Good Quality", Description = "Good quality, stayed fresh for a while, but some florets were a bit small." },
                new ProductReview { Id = 9, ProductId = 5, Rating = 4, Title = "Crunchy Carrots", Description = "Very crunchy and sweet, great for snacking and salads." },
                new ProductReview { Id = 10, ProductId = 5, Rating = 3, Title = "Decent Carrots", Description = "Not the best, but still okay. A few were a bit limp." },
                new ProductReview { Id = 11, ProductId = 6, Rating = 5, Title = "Ripe Tomatoes", Description = "Perfectly ripe and juicy tomatoes, ideal for sandwiches and salads." },
                new ProductReview { Id = 12, ProductId = 6, Rating = 4, Title = "Good Pack", Description = "Nice pack of tomatoes, good for salads, but a couple were a bit soft." },
                new ProductReview { Id = 13, ProductId = 7, Rating = 4, Title = "Starchy Potatoes", Description = "Good for baking and mashing, with a nice fluffy texture when cooked." },
                new ProductReview { Id = 14, ProductId = 7, Rating = 3, Title = "Average Potatoes", Description = "Some were a bit small, but overall okay for general use." },
                new ProductReview { Id = 15, ProductId = 8, Rating = 5, Title = "Whole Wheat Bread", Description = "Tasty and healthy, loved the texture and flavor, perfect for sandwiches." },
                new ProductReview { Id = 16, ProductId = 8, Rating = 4, Title = "Good Bread", Description = "Fresh and soft, very good quality, but could use a bit more fiber." },
                new ProductReview { Id = 17, ProductId = 9, Rating = 5, Title = "Fresh Milk", Description = "Tastes fresh and creamy, perfect for cereals and drinking straight." },
                new ProductReview { Id = 18, ProductId = 9, Rating = 4, Title = "Good Milk", Description = "Nice fresh milk, kids loved it, but a bit pricey." },
                new ProductReview { Id = 19, ProductId = 10, Rating = 5, Title = "Cheddar Cheese", Description = "Rich and creamy, great for sandwiches and snacking, with a sharp flavor." },
                new ProductReview { Id = 20, ProductId = 10, Rating = 4, Title = "Good Cheese", Description = "Nice flavor and texture, good for snacks and cooking." },
                new ProductReview { Id = 21, ProductId = 11, Rating = 4, Title = "Greek Yogurt", Description = "Thick and creamy, perfect for breakfast with honey and nuts." },
                new ProductReview { Id = 22, ProductId = 11, Rating = 5, Title = "Excellent Yogurt", Description = "Loved the texture and taste, very fresh and tangy." },
                new ProductReview { Id = 23, ProductId = 12, Rating = 5, Title = "Juicy Chicken Breast", Description = "Very juicy and tender, great for grilling and stir-fries." },
                new ProductReview { Id = 24, ProductId = 12, Rating = 4, Title = "Good Chicken", Description = "Good quality, cooked up nicely, but a bit on the expensive side." },
                new ProductReview { Id = 25, ProductId = 13, Rating = 5, Title = "Juicy Beef Steak", Description = "Excellent steak, very juicy and flavorful, perfect for grilling." },
                new ProductReview { Id = 26, ProductId = 13, Rating = 4, Title = "Good Steak", Description = "Nice flavor, cooked up well, but slightly tough in some parts." },
                new ProductReview { Id = 27, ProductId = 14, Rating = 5, Title = "Fresh Salmon Fillet", Description = "Very fresh and flavorful, great for grilling or baking." },
                new ProductReview { Id = 28, ProductId = 14, Rating = 4, Title = "Good Salmon", Description = "Nice fillet, good taste, but a bit pricey." },
                new ProductReview { Id = 29, ProductId = 15, Rating = 5, Title = "Frozen Shrimp", Description = "Tasty and convenient, easy to cook and perfect for pasta dishes." },
                new ProductReview { Id = 30, ProductId = 15, Rating = 4, Title = "Good Shrimp", Description = "Nice flavor, good quality, but a bit too many small ones." },
                new ProductReview { Id = 31, ProductId = 16, Rating = 4, Title = "Whole Grain Pasta", Description = "Good texture and taste, healthy option for pasta dishes." },
                new ProductReview { Id = 32, ProductId = 16, Rating = 3, Title = "Decent Pasta", Description = "Not bad, but I prefer other brands for a more robust flavor." },
                new ProductReview { Id = 33, ProductId = 17, Rating = 5, Title = "Long Grain Rice", Description = "Cooks up nicely, good quality rice, perfect for pilafs and side dishes." },
                new ProductReview { Id = 34, ProductId = 17, Rating = 4, Title = "Good Rice", Description = "Nice texture, cooked evenly, but a bit sticky." },
                new ProductReview { Id = 35, ProductId = 18, Rating = 5, Title = "Rolled Oats", Description = "Perfect for breakfast, very fresh and great for overnight oats." },
                new ProductReview { Id = 36, ProductId = 18, Rating = 4, Title = "Good Oats", Description = "Nice quality, good for overnight oats and baking." },
                new ProductReview { Id = 37, ProductId = 19, Rating = 5, Title = "Raw Almonds", Description = "Crunchy and fresh, perfect snack, and great for adding to salads." },
                new ProductReview { Id = 38, ProductId = 19, Rating = 4, Title = "Good Almonds", Description = "Nice flavor, good quality, but a few were a bit bitter." },
                new ProductReview { Id = 39, ProductId = 20, Rating = 5, Title = "Creamy Peanut Butter", Description = "Rich and creamy, perfect for sandwiches and baking. Great taste." },
                new ProductReview { Id = 40, ProductId = 20, Rating = 4, Title = "Tasty Peanut Butter", Description = "Nice and smooth, great for spreading, but a bit too sweet for my liking." });
            #endregion
        }



    }
}
