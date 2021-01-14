using System;
using System.Threading.Tasks;
using NLayerWebApiProject.Core.Repository;

namespace NLayerWebApiProject.Core.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get;  }
        
        Task CommitAsync();
        void Commit();
    }
}