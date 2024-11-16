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

        public async Task<TransactionStatus> Put(OrderDTO order)
        {
            try
            {

                var mappedOrder = new Order(order);

                await _dbContext.Orders.AddAsync(mappedOrder);

                int transactionCount = await _dbContext.SaveChangesAsync();

                if (transactionCount <= 0) return TransactionStatus.Failed;

                return TransactionStatus.Success;

            } catch(Exception ex) 
            {
                return TransactionStatus.Failed;
            }
        }

    }
}
