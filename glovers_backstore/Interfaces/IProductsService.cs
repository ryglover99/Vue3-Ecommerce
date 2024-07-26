using glovers_backstore.Data.Models;
namespace glovers_backstore.Interfaces
{
    public interface IProductsService
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProduct(int id);

        public Task<List<Product>> GetLimitedProducts(int amount);

        public Task<List<string>> GetAllCategories();

        public Task<List<Product>> GetAllProductsInCategory(string category);

        public Task<List<ProductReview>> GetAllReviewsForProduct(int productId);
    }
}
