using ECommerce.Application.Interfaces.Queries;
using ECommerce.Domain.Entities.Common;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories.Queries
{
    public class CategoryQueryRepository(
        AppDbContext appDbContext
    ) : ICategoryQueryRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _appDbContext.Categories
                .ToListAsync();

            return categories;
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            var category = await _appDbContext.Categories
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            return category;
        }
    }
}
