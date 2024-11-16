using glovers_backstore.Business.Enums.Orders;
using glovers_backstore.Data.Models;

namespace glovers_backstore.Business.DTOs
{
    public class OrderRequestDTO
    {
        public PaymentMethod PaymentMethod { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public List<BasketDTO> BasketItems { get; set; } = new List<BasketDTO>();
    }
}
