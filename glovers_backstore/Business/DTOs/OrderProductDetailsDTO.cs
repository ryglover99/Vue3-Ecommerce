using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using glovers_backstore.Business.DTOs;

namespace glovers_backstore.Data.Models
{
    public class OrderProductDetailsDTO
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
