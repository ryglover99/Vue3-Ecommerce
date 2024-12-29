using glovers_backstore.Business.DTOs.Order;
using glovers_backstore.Business.Enums.Orders;
using System.Text.Json.Serialization;

namespace glovers_backstore.Data.Models
{
    public class Order
    {
        public Order() { }
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime TS { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderProductDetails> OrderProductDetails { get; set; } = new List<OrderProductDetails>();
        public PaymentMethod PaymentMethod { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;

    }


}
