using System.Collections.Generic;

namespace NLayerWebApiProject.WebUI.DTOs
{
    public class CategoryWithProductsDTO: CategoryDTO
    {
        public ICollection<ProductDTO> Products { get; set; }
    }
}