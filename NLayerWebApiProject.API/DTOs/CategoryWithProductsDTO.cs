using System.Collections.Generic;

namespace NLayerWebApiProject.API.DTOs
{
    public class CategoryWithProductsDTO: CategoryDTO
    {
        public ICollection<ProductDTO> Products { get; set; }
    }
}