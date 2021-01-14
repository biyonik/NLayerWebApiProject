using System.Threading.Tasks;
using NLayerWebApiProject.Core.Models;

namespace NLayerWebApiProject.Core.Services
{
    public interface IProductService: IService<Product>
    {
        // bool ControlInnerBarcode(Product product);
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}