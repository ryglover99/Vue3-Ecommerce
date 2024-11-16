using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace glovers_backstore.Data.Models
{
    public class ProductReview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Product Product { get; set; } // navigation prop
        public int ProductId { get; set; } // FK
        public int Rating {  get; set; }
        public string Description { get; set; }
    }
}
