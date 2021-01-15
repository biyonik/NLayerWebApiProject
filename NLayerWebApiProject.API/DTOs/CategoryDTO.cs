using System.ComponentModel.DataAnnotations;
using NLayerWebApiProject.Core.Abstract;

namespace NLayerWebApiProject.API.DTOs
{
    public class CategoryDTO : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}