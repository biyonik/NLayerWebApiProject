using System.Threading.Tasks;
using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.Core.Repository;
using NLayerWebApiProject.Core.Services;
using NLayerWebApiProject.Core.UnitOfWorks;

namespace NLayerWebApiProject.Service.Services
{
    public class CategoryService: Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}