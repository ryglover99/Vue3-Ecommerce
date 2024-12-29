using glovers_backstore.Business.Enums.Orders;

namespace glovers_backstore.Business.DTOs.Order
{
    public class OrderResponseDTO
    {
        public OrderResponseDTO() { }

        public string Number { get; set; } = string.Empty;
        public DateTime TS { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderProductDetailsDTO> OrderProductDetails { get; set; } = new List<OrderProductDetailsDTO>();
        public PaymentMethod PaymentMethod { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
    }
}
