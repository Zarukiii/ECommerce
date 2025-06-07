using ECommerce.Application.Dto;
using ECommerce.Application.Services.ProductServices.Commands;
using ECommerce.Application.Services.ProductServices.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(
        IProductCommandService productCommandService,
        IProductQueryService productQueryService
    ) : ControllerBase
    {
        private readonly IProductCommandService _productCommandService = productCommandService;
        private readonly IProductQueryService _productQueryService = productQueryService;

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllActiveProducts()
        {
            var products = await _productQueryService.GetActiveProducts();
            return Ok(products);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _productQueryService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productQueryService.GetProductById(id);

                return Ok(product);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            await _productCommandService.CreateProduct(productDto);

            return CreatedAtAction(nameof(CreateProduct), productDto);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDto product, int id)
        {
            if (id == 0)
                return NotFound();

            await _productCommandService.UpdateProduct(product, id);

            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                await _productCommandService.DeleteProduct(id);

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
