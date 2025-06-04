using ECommerce.Application.Interfaces.Commands;
using ECommerce.Application.Interfaces.Queries;
using ECommerce.Domain.Entities.Common;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories.Commands
{
    public class CategoryCommandRepository(
        AppDbContext appDbContext,
        ICategoryQueryRepository queryRepository
    ) : ICategoryCommandRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        private readonly ICategoryQueryRepository _queryRepository = queryRepository;
        public async Task CreateCategory(Category category)
        {
            await _appDbContext.Categories.AddAsync(category);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _appDbContext.Categories.Update(category);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _queryRepository.GetCategoryById(id);

            if (category == null)
                throw new KeyNotFoundException();

            var categoryEntry = _appDbContext.Categories.Entry(category);

            categoryEntry.Property("IsDeleted").CurrentValue = true;

            await _appDbContext.SaveChangesAsync();
        }
    }
}
