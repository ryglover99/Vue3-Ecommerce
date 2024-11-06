using glovers_backstore.Business.Enums.Products;
using glovers_backstore.Data.Models;
namespace glovers_backstore.Interfaces
{
    public interface IProductsService
    {
        public Task<List<Product>> Get();
        public Task<Product> Get(int id);

        public Task<List<Product>> Get(ProductCategoryEnum category);

        public Task<List<Product>> GetLimited(int amount);

        public Task<List<string>> GetCategories();

        public Task<List<ProductReview>> GetReviews(int productId);
    }
}
