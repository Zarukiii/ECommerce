using ECommerce.Application.Dto;
using ECommerce.Application.Interfaces.Commands;
using ECommerce.Application.Interfaces.Queries;
using ECommerce.Application.Services.ProductServices.Commands;
using ECommerce.Application.Services.ProductServices.Queries;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(
        IProductCommandService productCommandService,
        IProductQueryService productQueryService) 
        : ControllerBase
    {
        private readonly IProductCommandService _productCommandService = productCommandService;
        private readonly IProductQueryService _productQueryService = productQueryService;

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _productQueryService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _productQueryService.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            await _productCommandService.CreateProduct(productDto);

            return CreatedAtAction(nameof(CreateProduct), productDto);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDto product, int id)
        {
            if (id == null)
                return NotFound();

            await _productCommandService.UpdateProduct(product, id);

            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            if (id == null)
                return NotFound();

            await _productCommandService.DeleteProduct(id);

            return NoContent();
        }
    }
}
