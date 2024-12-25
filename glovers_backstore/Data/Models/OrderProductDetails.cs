using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace glovers_backstore.Data.Models
{
    public class OrderProductDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        //public Order Order { get; set; } = null!;
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
