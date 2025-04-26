using ECommerce.Application.Dto;
using ECommerce.Application.Interfaces.Commands;
using ECommerce.Application.Interfaces.Queries;
using ECommerce.Application.Services.ProductServices.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TestController(IProductQueryRepository productQueryRepository, IProductCommandRepository productCommandRepository, IProductCommandService productService) : ControllerBase
    {
        private readonly IProductQueryRepository _productQueryRepository = productQueryRepository;
        private readonly IProductCommandRepository _productCommandRepository = productCommandRepository;
        private readonly IProductCommandService _productService = productService;

        [HttpGet("AllProducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _productQueryRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("ProductByID")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _productQueryRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            await _productService.CreateProduct(productDto);

            return CreatedAtAction(nameof(CreateProduct), productDto);
        }
    }
}
