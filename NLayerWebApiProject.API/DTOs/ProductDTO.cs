using System.ComponentModel.DataAnnotations;
using NLayerWebApiProject.Core.Models;

namespace NLayerWebApiProject.API.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}