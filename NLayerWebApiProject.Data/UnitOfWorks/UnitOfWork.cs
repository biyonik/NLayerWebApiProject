using System;
using System.Threading.Tasks;
using NLayerWebApiProject.Core.Repository;
using NLayerWebApiProject.Core.UnitOfWorks;
using NLayerWebApiProject.Data.Repositories;

namespace NLayerWebApiProject.Data.UnitOfWorks
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _appDbContext;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private bool _disposed;
        
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _appDbContext.Dispose();
                }
            }

            _disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IProductRepository Products => _productRepository ?? new ProductRepository(_appDbContext);
        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_appDbContext);
        
        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }
    }
}