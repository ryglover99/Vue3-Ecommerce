using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using glovers_backstore.Business.DTOs;

namespace glovers_backstore.Data.Models
{
    public class Product
    {
        public Product() { }
        public Product(ProductDTO productDTO)
        {
            Title = productDTO.Title;
            Price = productDTO.Price;
            Category = productDTO.Category;
            Description = productDTO.Description;
            Image   = productDTO.Image;
            NutritionImage = productDTO.NutritionImage;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string NutritionImage { get; set; }
    }
}
