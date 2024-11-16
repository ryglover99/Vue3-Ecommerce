using glovers_backstore.Data;
using glovers_backstore.Data.Models;
using Microsoft.EntityFrameworkCore;
using glovers_backstore.Business.Interfaces;
using glovers_backstore.Data.Enums;
using glovers_backstore.Business.DTOs;

namespace glovers_backstore.Services
{
    public class OrderService : IOrderService
    {
        private readonly StoreDbContext _dbContext;

        public OrderService(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> Get(string number)
        {
           return await _dbContext.Orders.FirstOrDefaultAsync(o => o.Number == number);
        }

        public async Task<UnitOfWork<Order>> Put(OrderRequestDTO order)
        {
            var mappedOrder = new Order(order);

            try
            {
                await _dbContext.Orders.AddAsync(mappedOrder);

                int transactionCount = await _dbContext.SaveChangesAsync();

                if (transactionCount <= 0) 
                    return new UnitOfWork<Order>(new Order(), TransactionStatus.Failed);

            } catch(Exception ex) 
            {
               // Log
            }

            return new UnitOfWork<Order>(mappedOrder, TransactionStatus.Success);
        }

    }
}
