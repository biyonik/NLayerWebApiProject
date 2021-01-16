using System.ComponentModel.DataAnnotations;
using NLayerWebApiProject.Core.Abstract;

namespace NLayerWebApiProject.WebUI.DTOs
{
    public class CategoryDTO : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string Name { get; set; }
    }
}