using System.Threading.Tasks;
using NLayerWebApiProject.Core.Models;

namespace NLayerWebApiProject.Core.Repository
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}