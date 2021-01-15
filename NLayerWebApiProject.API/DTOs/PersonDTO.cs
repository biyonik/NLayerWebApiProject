using System.ComponentModel.DataAnnotations;

namespace NLayerWebApiProject.API.DTOs
{
    public class PersonDTO
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        public int Age { get; set; }
    }
}