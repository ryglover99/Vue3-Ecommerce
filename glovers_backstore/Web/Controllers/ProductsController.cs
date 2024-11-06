using glovers_backstore.Data.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using glovers_backstore.Interfaces;
using glovers_backstore.Business.Enums.Products;

namespace glovers_backstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductsController : ControllerBase
    {
        /* TODO: 
         * Return HTTP responses
         * Use standardised REST methods, PUT GET DELETE
         * Logging
         * JWT Auth
         * Cancellation Tokens
        */

        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("getAllProducts")]
        [ProducesResponseType(200)]
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productsService.Get();
        }

        [HttpGet("getProduct/{id}")]
        [ProducesResponseType(200)]
        public async Task<Product> GetSingleProduct(int id)
        {
            return await _productsService.Get(id);
        }

        [HttpGet("getAllProducts/{amount:int}")]
        [ProducesResponseType(200)]
        public async Task<List<Product>> GetLimitedProducts(int amount)
        {
            return await _productsService.GetLimited(amount);
        }

        [HttpGet("getAllCategories")]
        [ProducesResponseType(200)]
        public async Task<List<string>> GetAllCategories()
        {
            return await _productsService.GetCategories();
        }

        [HttpGet("getAllProducts/{category}")]
        [ProducesResponseType(200)]
        public async Task<List<Product>> GetAllProductsInCategory(string category)
        {
            var result = Enum.TryParse(category, true, out ProductCategoryEnum parsedCategory);

            if (!result) { return new List<Product>(); }

            return await _productsService.Get(parsedCategory);
        }

        [HttpGet("getReviews/{id}")]
        [ProducesResponseType(200)]

        public async Task<List<ProductReview>> GetReviewsForProduct(int id)
        {
            return await _productsService.GetReviews(id);
        }

    }
}
