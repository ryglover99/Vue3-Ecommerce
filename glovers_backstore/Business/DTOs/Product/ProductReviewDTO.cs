namespace glovers_backstore.Business.DTOs.Product
{
    public class ProductReviewDTO
    {
        public string Title { get; set; }
        public ProductDTO Product { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }
}
