using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.Core.Repository;

namespace NLayerWebApiProject.Data.Repositories
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        private AppDbContext AppDbContext => Context as AppDbContext;

        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await AppDbContext.Categories.Include(c => c.Products).SingleOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}