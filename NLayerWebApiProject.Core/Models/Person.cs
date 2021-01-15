using NLayerWebApiProject.Core.Abstract;

namespace NLayerWebApiProject.Core.Models
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
    }
}