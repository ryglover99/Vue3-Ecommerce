using glovers_backstore.Data;
using glovers_backstore.Data.Models;
using Microsoft.EntityFrameworkCore;
using glovers_backstore.Interfaces;
using glovers_backstore.Business.Interfaces;
using glovers_backstore.Data.Enums;

namespace glovers_backstore.Services
{
    public class OrderService : IOrderService
    {
        private readonly StoreDbContext _dbContext;

        public OrderService(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> Get(int number)
        {
           return await _dbContext.Orders.FirstOrDefaultAsync(o => o.Number == number);
        }

        public async Task<TransactionStatus> Put(Order order)
        {
            await _dbContext.Orders.AddAsync(order);

            int transactionCount = await _dbContext.SaveChangesAsync();

            if (transactionCount <= 0) return TransactionStatus.Failed;

            return TransactionStatus.Success;

        }
    }
}
