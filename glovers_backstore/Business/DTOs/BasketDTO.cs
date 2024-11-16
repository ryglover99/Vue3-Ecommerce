using glovers_backstore.Data.Models;

namespace glovers_backstore.Business.DTOs
{
    public class BasketDTO
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
