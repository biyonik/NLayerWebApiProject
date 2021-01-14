using System.Threading.Tasks;
using NLayerWebApiProject.Core.Models;

namespace NLayerWebApiProject.Core.Repository
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}