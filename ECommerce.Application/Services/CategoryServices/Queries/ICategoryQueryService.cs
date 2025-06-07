using ECommerce.Application.Dto;

namespace ECommerce.Application.Services.CategoryServices.Queries
{
    public interface ICategoryQueryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategoryById(int id);
    }
}
