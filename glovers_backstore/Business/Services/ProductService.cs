using glovers_backstore.Data;
using glovers_backstore.Data.Models;
using Microsoft.EntityFrameworkCore;
using glovers_backstore.Interfaces;
using glovers_backstore.Business.Enums.Products;
using glovers_backstore.Business.DTOs.Product;
using glovers_backstore.Data.Enums;
using glovers_backstore.Business.Mapping;

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
        public async Task<UnitOfWork<List<ProductDTO>>> Get()
        {
            var products = await _dbContext.Products.ToListAsync();

            if(products.Count <= 0)
            {
                return new UnitOfWork<List<ProductDTO>>(new List<ProductDTO>(), TransactionStatus.NotFound);
            }

            try
            {
                var productDtos = products.Select(p => p.MapToDTO()).ToList();
                return new UnitOfWork<List<ProductDTO>>(productDtos, TransactionStatus.Success);

            } catch (Exception ex) 
            {
                return new UnitOfWork<List<ProductDTO>>(new List<ProductDTO>(), TransactionStatus.Failed);
            }
        }

        public async Task<UnitOfWork<ProductDTO>> Get(int id)
        {
            var product = await _dbContext.Products.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();

            if (product == null)
            {
                return new UnitOfWork<ProductDTO>(new ProductDTO(), TransactionStatus.NotFound);
            }

            try
            {
                var productDto = product.MapToDTO();
                return new UnitOfWork<ProductDTO>(productDto, TransactionStatus.Success);

            }
            catch (Exception ex)
            {
                return new UnitOfWork<ProductDTO>(new ProductDTO(), TransactionStatus.Failed);
            }
        }

        public async Task<UnitOfWork<List<ProductDTO>>> Get(ProductCategoryEnum category)
        {
            var products = await _dbContext.Products.Where(p => p.Category.Equals(category.ToString())).ToListAsync();

            if (products.Count <= 0)
            {
                return new UnitOfWork<List<ProductDTO>>(new List<ProductDTO>(), TransactionStatus.NotFound);
            }

            try
            {
                var productDtos = products.Select(p => p.MapToDTO()).ToList();
                return new UnitOfWork<List<ProductDTO>>(productDtos, TransactionStatus.Success);

            }
            catch (Exception ex)
            {
                return new UnitOfWork<List<ProductDTO>>(new List<ProductDTO>(), TransactionStatus.Failed);
            }
        }

        public async Task<UnitOfWork<List<ProductDTO>>> GetLimited(int amount)
        {
            var products = await _dbContext.Products.Take(amount).ToListAsync();

            if (products.Count <= 0)
            {
                return new UnitOfWork<List<ProductDTO>>(new List<ProductDTO>(), TransactionStatus.NotFound);
            }

            try
            {
                var productDtos = products.Select(p => p.MapToDTO()).ToList();
                return new UnitOfWork<List<ProductDTO>>(productDtos, TransactionStatus.Success);

            }
            catch (Exception ex)
            {
                return new UnitOfWork<List<ProductDTO>>(new List<ProductDTO>(), TransactionStatus.Failed);
            }
        }

        public async Task<UnitOfWork<List<string>>> GetCategories()
        {
            var categories = await _dbContext.Products.GroupBy(p => p.Category).Select(c => c.Key).ToListAsync();

            if (categories.Count <= 0)
            {
                return new UnitOfWork<List<string>>(new List<string>(), TransactionStatus.NotFound);
            }

            try
            {
                return new UnitOfWork<List<string>>(categories, TransactionStatus.Success);

            }
            catch (Exception ex)
            {
                return new UnitOfWork<List<string>>(new List<string>(), TransactionStatus.Failed);
            }
        }

        public async Task<UnitOfWork<List<ProductReviewDTO>>> GetReviews(int productId)
        {
            var reviewEntities = await _dbContext.ProductReviews.Where(pr => pr.ProductId.Equals(productId)).ToListAsync();

            if (reviewEntities.Count <= 0)
            {
                return new UnitOfWork<List<ProductReviewDTO>>(new List<ProductReviewDTO>(), TransactionStatus.NotFound);
            }

            try
            {
                var reviewDTOs = reviewEntities.Select(r => r.MapToDTO()).ToList();
                return new UnitOfWork<List<ProductReviewDTO>>(reviewDTOs, TransactionStatus.Success);

            }
            catch (Exception ex)
            {
                return new UnitOfWork<List<ProductReviewDTO>>(new List<ProductReviewDTO>(), TransactionStatus.Failed);
            }
        }

        #endregion

    }
}
