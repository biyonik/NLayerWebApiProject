using NLayerWebApiProject.Core.Models;

namespace NLayerWebApiProject.API.DTOs
{
    public class ProductWithCategoryDTO: ProductDTO
    {
        public CategoryDTO Category { get; set; }
        
    }
}