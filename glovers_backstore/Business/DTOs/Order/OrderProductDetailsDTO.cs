using glovers_backstore.Business.DTOs.Product;

namespace glovers_backstore.Business.DTOs.Order
{
    public class OrderProductDetailsDTO
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
