using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.Core.Repository;
using NLayerWebApiProject.Core.Services;
using NLayerWebApiProject.Core.UnitOfWorks;

namespace NLayerWebApiProject.Service.Services
{
    public class PersonService: Service<Person>, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork, IGenericRepository<Person> repository) : base(unitOfWork, repository)
        {
        }
    }
}