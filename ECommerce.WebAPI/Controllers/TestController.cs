using ECommerce.Application.Dto;
using ECommerce.Application.Interfaces.Commands;
using ECommerce.Application.Interfaces.Queries;
using ECommerce.Application.Services.ProductServices.Commands;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(IProductQueryRepository productQueryRepository, IProductCommandRepository productCommandRepository, IProductCommandService productService) : ControllerBase
    {
        private readonly IProductQueryRepository _productQueryRepository = productQueryRepository;
        private readonly IProductCommandRepository _productCommandRepository = productCommandRepository;
        private readonly IProductCommandService _productService = productService;

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _productQueryRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _productQueryRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            await _productService.CreateProduct(productDto);

            return CreatedAtAction(nameof(CreateProduct), productDto);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDto product, int id)
        {
            await _productService.UpdateProduct(product, id);

            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productCommandRepository.DeleteProductAsync(id);

            return NoContent();
        }
    }
}
