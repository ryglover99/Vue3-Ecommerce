using glovers_backstore.Business.Enums.Orders;
using glovers_backstore.Data.Models;

namespace glovers_backstore.Business.DTOs
{
    public class OrderResponseDTO
    {
        public OrderResponseDTO() { }

        public OrderResponseDTO(Order order) { }
        public string Number { get; set; } = string.Empty;
        public DateTime TS { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderProductDetailsDTO> OrderProductDetails { get; set; } = new List<OrderProductDetailsDTO>();
        public PaymentMethod PaymentMethod { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
    }
}
