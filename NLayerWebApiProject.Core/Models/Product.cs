using NLayerWebApiProject.Core.Abstract;

namespace NLayerWebApiProject.Core.Models
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}