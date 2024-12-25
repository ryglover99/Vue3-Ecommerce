using glovers_backstore.Business.DTOs;
using glovers_backstore.Business.Enums.Orders;
using System.Text.Json.Serialization;

namespace glovers_backstore.Data.Models
{
    public class Order
    {
        private readonly Random random = new Random();

        public Order() { }
        public Order(OrderRequestDTO orderDTO) 
        {
            Number = GenerateOrderNumber(random);
            TS = DateTime.Now;
            Status = OrderStatus.Pending;
            OrderProductDetails = GenerateOrderProductDetails(orderDTO, this);
            PaymentMethod = orderDTO.PaymentMethod;
            Firstname = orderDTO.Firstname;
            Lastname = orderDTO.Lastname;
            Address = orderDTO.Address;
            Address2 = orderDTO.Address2;
            Postcode = orderDTO.Postcode;
        }

        [JsonIgnore]
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

        private string GenerateOrderNumber(Random random)
        {
            int randomPart = random.Next(100000, 999999);
            string orderNumber = $"ORD-{randomPart}-{DateTime.Now.Ticks % 10000}";
            return orderNumber;
        }

        private ICollection<OrderProductDetails> GenerateOrderProductDetails(OrderRequestDTO orderDTO, Order order)
        {
            if (orderDTO.BasketItems.Count <= 0) throw new ArgumentException("Empty Products");

            var collection = new List<OrderProductDetails>();

            foreach (var basketItem in orderDTO.BasketItems)
            {           
                var productDetails = new OrderProductDetails();
                productDetails.OrderId = order.Id;
                productDetails.Product = new Product(basketItem.Product);
                productDetails.Quantity = basketItem.Quantity;

                collection.Add(productDetails);
            }

            return collection;
        }

    }


}
