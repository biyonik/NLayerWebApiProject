using System.Threading.Tasks;
using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.Core.Repository;
using NLayerWebApiProject.Core.Services;
using NLayerWebApiProject.Core.UnitOfWorks;

namespace NLayerWebApiProject.Service.Services
{
    public class ProductService: Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}