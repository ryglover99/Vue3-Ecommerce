using glovers_backstore.Interfaces;
using glovers_backstore.Data.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace glovers_backstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService) 
        {
            _productsService = productsService;
        } 

        [HttpGet("getAllProducts")]
        [ProducesResponseType(200)]
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productsService.GetAllProducts();
        }

        [HttpGet("getProduct/{id}")]
        [ProducesResponseType(200)]
        public async Task<Product> GetSingleProduct(int id)
        {
            return await _productsService.GetProduct(id);
        }

        [HttpGet("getAllProducts/{amount:int}")]
        [ProducesResponseType(200)]
        public async Task<List<Product>> GetLimitedProducts(int amount)
        {
            return await _productsService.GetLimitedProducts(amount);
        }

        [HttpGet("getAllCategories")]
        [ProducesResponseType(200)]
        public async Task<List<string>> GetAllCategories()
        {
            return await _productsService.GetAllCategories();
        }

        [HttpGet("getAllProducts/{category}")]
        [ProducesResponseType(200)]
        public async Task<List<Product>> GetAllProductsInCategory(string category)
        {
            return await _productsService.GetAllProductsInCategory(category);
        }

        [HttpGet("getReviews/{id}")]
        [ProducesResponseType(200)]

        public async Task<List<ProductReview>> GetReviewsForProduct(int id)
        {
            var p = await _productsService.GetAllReviewsForProduct(id);
            return p;
        }

    }
}
