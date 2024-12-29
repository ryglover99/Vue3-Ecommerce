using glovers_backstore.Business.DTOs.Order;
using glovers_backstore.Business.Enums.Orders;
using glovers_backstore.Data.Models;
using System;

namespace glovers_backstore.Business.Mapping
{
    public static class OrderMapper
    {

        public static Order MapToEntity(this OrderRequestDTO orderDTO)
        => MapRequestToEntity(orderDTO);


        public static OrderResponseDTO MapToResponseDTO(this Order orderEntity)
        => new OrderResponseDTO()
        {
            Number = orderEntity.Number,
            TS = orderEntity.TS,
            Status = orderEntity.Status,
            OrderProductDetails = orderEntity.OrderProductDetails.Select(pd => pd.MapToDTO()),
            PaymentMethod = orderEntity.PaymentMethod,
            Firstname = orderEntity.Firstname,
            Lastname = orderEntity.Lastname,
            Address = orderEntity.Address,
            Address2 = orderEntity.Address2,
            Postcode = orderEntity.Postcode
        };

        private static OrderProductDetailsDTO MapToDTO(this OrderProductDetails orderProductDetails)
        => MapOrderProductDetailsToDTO(orderProductDetails);

        private static OrderProductDetailsDTO MapOrderProductDetailsToDTO(OrderProductDetails orderProductDetails)
        => new OrderProductDetailsDTO()
        {
            Quantity = orderProductDetails.Quantity
        };

        private static Order MapRequestToEntity(OrderRequestDTO request)
        {
            var order = new Order()
            {
                Number = GenerateOrderNumber(),
                TS = DateTime.Now,
                Status = OrderStatus.Pending,
                PaymentMethod = request.PaymentMethod,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Address = request.Address,
                Address2 = request.Address2,
                Postcode = request.Postcode
            };

            order.OrderProductDetails = GenerateOrderProductDetails(request, order);

            return order;
        }

        private static string GenerateOrderNumber()
        {
            Random randomGenerator = new Random();
            int randomPart = randomGenerator.Next(100000, 999999);
            string orderNumber = $"ORD-{randomPart}-{DateTime.Now.Ticks % 10000}";
            return orderNumber;
        }

        private static ICollection<OrderProductDetails> GenerateOrderProductDetails(OrderRequestDTO orderDTO, Order order)
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
