using glovers_backstore.Business.Enums.Orders;

namespace glovers_backstore.Business.DTOs.Order
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
