using glovers_backstore.Business.Enums;
using glovers_backstore.Controllers;

namespace glovers_backstore.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime TS { get; set; }
        public OrderStatus Status { get; set; }
    }
}
