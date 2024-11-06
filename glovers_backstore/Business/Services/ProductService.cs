using glovers_backstore.Data;
using glovers_backstore.Data.Models;
using Microsoft.EntityFrameworkCore;
using glovers_backstore.Interfaces;
using glovers_backstore.Business.Enums.Products;

namespace glovers_backstore.Services
{
    public class ProductService : IProductsService
    {
        private readonly StoreDbContext _dbContext;

        public ProductService(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region GET
        public async Task<List<Product>> Get()
            => await _dbContext.Products.ToListAsync();

        public async Task<Product> Get(int id)
             => await _dbContext.Products.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();

        public async Task<List<Product>> Get(ProductCategoryEnum category)
            => await _dbContext.Products.Where(p => p.Category.Equals(category.ToString())).ToListAsync();

        public async Task<List<Product>> GetLimited(int amount)
            => await _dbContext.Products.Take(amount).ToListAsync();

        public async Task<List<string>> GetCategories()
             => await _dbContext.Products.GroupBy(p => p.Category).Select(c => c.Key).ToListAsync();

        public async Task<List<ProductReview>> GetReviews(int productId)
            => await _dbContext.ProductReviews.Where(pr => pr.ProductId.Equals(productId)).ToListAsync();

        #endregion

    }
}
