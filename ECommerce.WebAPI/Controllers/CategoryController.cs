using ECommerce.Application.Dto;
using ECommerce.Application.Services.CategoryServices.Commands;
using ECommerce.Application.Services.CategoryServices.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(
        ICategoryQueryService queryService,
        ICategoryCommandService commandService
        ) : ControllerBase
    {
        ICategoryQueryService _queryService = queryService;
        ICategoryCommandService _commandService = commandService;

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _queryService.GetCategories();

                return Ok(categories);
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _queryService.GetCategoryById(id);

                return Ok(category);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCategory(CategoryDto categoryDto)
        {
            try
            {
                await _commandService.CreateCategory(categoryDto);

                return CreatedAtAction(nameof(CreateCategory), categoryDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCategory(CategoryDto categoryDto, int id)
        {
            try
            {
                await _commandService.UpdateCategory(categoryDto, id);

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _commandService.DeleteCategory(id);

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}