using glovers_backstore.Data;
using glovers_backstore.Data.Models;
using Microsoft.EntityFrameworkCore;
using glovers_backstore.Business.Interfaces;
using glovers_backstore.Data.Enums;
using glovers_backstore.Business.DTOs.Order;
using glovers_backstore.Business.Mapping;

namespace glovers_backstore.Services
{
    public class OrderService : IOrderService
    {
        private readonly StoreDbContext _dbContext;

        public OrderService(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UnitOfWork<OrderResponseDTO>> Get(string number)
        {
            var orderEntity = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Number == number);

            if (orderEntity == null)
                return new UnitOfWork<OrderResponseDTO>(new OrderResponseDTO(), TransactionStatus.Failed);

            return new UnitOfWork<OrderResponseDTO>(orderEntity.MapToResponseDTO(), TransactionStatus.Success);
        }

        public async Task<UnitOfWork<OrderResponseDTO>> Create(OrderRequestDTO order)
        {
            var mappedOrder = order.MapToEntity();

            try
            {
                await _dbContext.Orders.AddAsync(mappedOrder);

                int transactionCount = await _dbContext.SaveChangesAsync();

                if (transactionCount <= 0)
                    return new UnitOfWork<OrderResponseDTO>(new OrderResponseDTO(), TransactionStatus.Failed);

            }
            catch (Exception ex)
            {
                // Log
            }

            return new UnitOfWork<OrderResponseDTO>(mappedOrder.MapToResponseDTO(), TransactionStatus.Success);
        }

    }
}
