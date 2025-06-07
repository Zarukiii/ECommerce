using ECommerce.Application.Dto;
using ECommerce.Application.Interfaces.Commands;
using ECommerce.Application.Interfaces.Queries;
using ECommerce.Domain.Entities.Common;

namespace ECommerce.Application.Services.CategoryServices.Commands
{
    public class CategoryCommandService(
        ICategoryCommandRepository commandRepository,
        ICategoryQueryRepository queryRepository
    ) : ICategoryCommandService
    {
        private readonly ICategoryCommandRepository _commandRepository = commandRepository;
        private readonly ICategoryQueryRepository _queryRepository = queryRepository;

        public async Task CreateCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.CategoryName,
                IsDeleted = categoryDto.IsDeleted
            };

            await _commandRepository.CreateCategoryAsync(category);
        }

        public async Task DeleteCategory(int id)
        {
            await _commandRepository.DeleteCategoryAsync(id);
        }

        public async Task UpdateCategory(CategoryDto categoryDto, int id)
        {
            var category = await _queryRepository.GetCategoryById(id);

            if (category == null)
                throw new KeyNotFoundException();

            category.Name = categoryDto.CategoryName;
            category.IsDeleted = categoryDto.IsDeleted;

            await _commandRepository.UpdateCategoryAsync(category);
        }
    }
}
