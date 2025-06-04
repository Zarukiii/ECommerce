using ECommerce.Application.Dto;
using ECommerce.Application.Interfaces.Queries;

namespace ECommerce.Application.Services.CategoryServices.Queries
{
    public class CategoryQueryService(
        ICategoryQueryRepository queryRepository
        ) : ICategoryQueryService
    {
        private readonly ICategoryQueryRepository _queryRepository = queryRepository;
        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _queryRepository.GetCategories();

            var categoriesDto = categories.Select(category => new CategoryDto
            {
                CategoryName = category.Name,
                IsDeleted = category.IsDeleted
            });

            return categoriesDto;
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await _queryRepository.GetCategoryById(id);

            CategoryDto categoryDto = new CategoryDto
            {
                CategoryName = category.Name,
                IsDeleted = category.IsDeleted
            };

            return categoryDto;
        }
    }
}
