using System;
using System.Threading.Tasks;
using NLayerWebApiProject.Core.Repository;

namespace NLayerWebApiProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get;  }
        IPersonRepository Persons { get; }
        
        Task CommitAsync();
        void Commit();
    }
}