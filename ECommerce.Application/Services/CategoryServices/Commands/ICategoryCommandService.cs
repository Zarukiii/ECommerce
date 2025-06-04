using ECommerce.Application.Dto;

namespace ECommerce.Application.Services.CategoryServices.Commands
{
    public interface ICategoryCommandService
    {
        Task CreateCategory(CategoryDto categoryDto);
        Task UpdateCategory(CategoryDto categoryDto, int ids);
        Task DeleteCategory(int id);
    }
}
