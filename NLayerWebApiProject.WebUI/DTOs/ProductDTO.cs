using System;
using System.ComponentModel.DataAnnotations;

namespace NLayerWebApiProject.WebUI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        
        [Display(Name = "Adı")]
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Stok")]
        [Range(1, Int32.MaxValue, ErrorMessage = "{0} alanı geçerli bir değer olmalıdır!")]
        public int Stock { get; set; }
        
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Fiyat")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} alanı geçerli bir değer olmalıdır")]
        public decimal Price { get; set; }
        
        [Required]
        [Display(Name = "Kategori Id:")]
        public int CategoryId { get; set; }
    }
}