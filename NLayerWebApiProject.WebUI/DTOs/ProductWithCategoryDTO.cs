namespace NLayerWebApiProject.WebUI.DTOs
{
    public class ProductWithCategoryDTO: ProductDTO
    {
        public CategoryDTO Category { get; set; }
        
    }
}