namespace glovers_backstore.Data.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
