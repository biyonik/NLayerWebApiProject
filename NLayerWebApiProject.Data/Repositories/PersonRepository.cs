using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.Core.Repository;

namespace NLayerWebApiProject.Data.Repositories
{
    public class PersonRepository: Repository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }
    }
}