using System.Collections.Generic;
using System.Collections.ObjectModel;
using NLayerWebApiProject.Core.Abstract;

namespace NLayerWebApiProject.Core.Models
{
    public class Category: IEntity
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}