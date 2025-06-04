using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Dto;

namespace ECommerce.Application.Services.CategoryServices.Queries
{
    public interface ICategoryQueryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategoryById(int id);
    }
}
