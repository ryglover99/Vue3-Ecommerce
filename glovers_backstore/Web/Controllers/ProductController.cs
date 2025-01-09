using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using glovers_backstore.Interfaces;
using glovers_backstore.Business.Enums.Products;
using glovers_backstore.Data.Enums;

namespace glovers_backstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductController : ControllerBase
    {
        /* TODO: 
         * Use standardised REST methods, PUT GET DELETE
         * Logging
         * JWT Auth
         * Cancellation Tokens
        */

        private readonly IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("getAllProducts")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productsService.Get();

            switch (result.Status)
            {
                case TransactionStatus.Success:
                    return Ok(result.Data);
                case TransactionStatus.NotFound:
                    return NotFound();
                default: return Problem();
            }
        }

        [HttpGet("getProduct/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSingleProduct(int id)
        {
            var result = await _productsService.Get(id);

            switch (result.Status)
            {
                case TransactionStatus.Success:
                    return Ok(result.Data);
                case TransactionStatus.NotFound:
                    return NotFound();
                default: return Problem();
            }
        }

        [HttpGet("getAllProducts/{amount:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetLimitedProducts(int amount)
        {
            var result = await _productsService.GetLimited(amount);

            switch (result.Status)
            {
                case TransactionStatus.Success:
                    return Ok(result.Data);
                case TransactionStatus.NotFound:
                    return NotFound();
                default: return Problem();
            }
        }

        [HttpGet("getAllCategories")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _productsService.GetCategories();

            switch (result.Status)
            {
                case TransactionStatus.Success:
                    return Ok(result.Data);
                case TransactionStatus.NotFound:
                    return NotFound();
                default: return Problem();
            }
        }

        [HttpGet("getAllProducts/{category}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllProductsInCategory(string category)
        {
            var canParseEnum = Enum.TryParse(category, true, out ProductCategoryEnum parsedCategory);

            if (!canParseEnum) { return BadRequest(); }

            var result = await _productsService.Get(parsedCategory);

            switch (result.Status)
            {
                case TransactionStatus.Success:
                    return Ok(result.Data);
                case TransactionStatus.NotFound:
                    return NotFound();
                default: return Problem();
            }
        }

        [HttpGet("getReviews/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetReviewsForProduct(int id)
        {
            var result = await _productsService.GetReviews(id);

            switch (result.Status)
            {
                case TransactionStatus.Success:
                    return Ok(result.Data);
                case TransactionStatus.NotFound:
                    return NotFound();
                default: return Problem();
            }
        }

    }
}
