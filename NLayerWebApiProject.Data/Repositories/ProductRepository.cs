using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.Core.Repository;

namespace NLayerWebApiProject.Data.Repositories
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private AppDbContext AppDbContext => Context as AppDbContext;

        public ProductRepository(AppDbContext context) : base(context)
        {
            
        }
        
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await AppDbContext.Products.Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == productId);
        }
    }
}