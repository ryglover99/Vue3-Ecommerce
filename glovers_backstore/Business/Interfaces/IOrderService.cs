using glovers_backstore.Business.Enums;
using glovers_backstore.Data.Enums;
using glovers_backstore.Data.Models;

namespace glovers_backstore.Business.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> Get(int number);
        public Task<TransactionStatus> Put(Order order);
    }
}
