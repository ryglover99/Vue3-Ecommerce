using glovers_backstore.Business.DTOs.Product;
using glovers_backstore.Business.Enums.Products;
using glovers_backstore.Data.Models;

namespace glovers_backstore.Interfaces
{
    public interface IProductsService
    {
        public Task<UnitOfWork<List<ProductDTO>>> Get();
        public Task<UnitOfWork<ProductDTO>> Get(int id);

        public Task<UnitOfWork<List<ProductDTO>>> Get(ProductCategoryEnum category);

        public Task<UnitOfWork<List<ProductDTO>>> GetLimited(int amount);

        public Task<UnitOfWork<List<string>>> GetCategories();

        public Task<UnitOfWork<List<ProductReviewDTO>>> GetReviews(int productId);
    }
}
