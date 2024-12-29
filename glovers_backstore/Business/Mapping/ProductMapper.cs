using glovers_backstore.Business.DTOs.Product;
using glovers_backstore.Data.Models;

namespace glovers_backstore.Business.Mapping
{
    public static class ProductMapper
    {
        public static ProductDTO MapToDTO(this Product product)
        => new ProductDTO()
        {
            Id = product.Id,
            Title = product.Title,
            Price = product.Price,
            Category = product.Category,
            Description = product.Description,
            Image = product.Image,
            NutritionImage = product.NutritionImage
        };

        public static ProductReviewDTO MapToDTO(this ProductReview productReview)
        => new ProductReviewDTO()
        {
            Title = productReview.Title,
            Product = productReview.Product.MapToDTO(),
            Rating = productReview.Rating,
            Description = productReview.Description
        };
    }
}
