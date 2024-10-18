using glovers_backstore.Data;
using glovers_backstore.Data.Models;
using glovers_backstore.Services.Base;
using Microsoft.EntityFrameworkCore;
using glovers_backstore.Interfaces;

namespace glovers_backstore.Services
{
    public class ProductsService : BaseApiService, IProductsService
    {
        private readonly StoreDbContext _dbContext;

        public ProductsService(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProducts()
            => await _dbContext.Products.ToListAsync();

        public async Task<Product> GetProduct(int id)
             => await _dbContext.Products.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
        

        public async Task<List<Product>> GetLimitedProducts(int amount)
            => await _dbContext.Products.Take(amount).ToListAsync();


        public async Task<List<string>> GetAllCategories()
             => await _dbContext.Products.GroupBy(p => p.Category).Select(c => c.Key).ToListAsync();

        public async Task<List<Product>> GetAllProductsInCategory(string category)
            => await _dbContext.Products.Where(p => p.Category.Equals(category)).ToListAsync();

        public async Task<List<ProductReview>> GetAllReviewsForProduct(int productId)
            => await _dbContext.ProductReviews.Where(pr => pr.ProductId.Equals(productId)).ToListAsync();

    }
}
