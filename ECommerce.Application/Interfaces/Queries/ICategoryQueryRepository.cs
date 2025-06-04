using ECommerce.Domain.Entities.Common;

namespace ECommerce.Application.Interfaces.Queries
{
    public interface ICategoryQueryRepository
    {
        Task<Category?> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetCategories();
    }
}
