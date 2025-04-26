using ECommerce.Application.Dto;
using ECommerce.Application.Interfaces.Commands;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.ProductServices.Commands
{
    public class ProductCommandService(IProductCommandRepository productCommandRepository) : IProductCommandService
    {
        private readonly IProductCommandRepository _productCommandRepository = productCommandRepository;
        public async Task CreateProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                ParentCategoryId = productDto.ParentCat,
                SubCategoryId = productDto.SubCat,
                Price = productDto.Price,
                StockQuantity = productDto.Stock,
                ImageUrl = productDto.ImageUrl,
                Status = productDto.Status
            };

            await _productCommandRepository.CreateProductAsync(product);
        }
    }
}
