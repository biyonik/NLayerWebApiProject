using System.Threading.Tasks;
using NLayerWebApiProject.Core.Models;

namespace NLayerWebApiProject.Core.Services
{
    public interface ICategoryService: IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}