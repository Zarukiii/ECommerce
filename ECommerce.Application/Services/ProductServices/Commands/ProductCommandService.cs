using ECommerce.Application.Dto;
using ECommerce.Application.Interfaces.Commands;
using ECommerce.Application.Interfaces.Queries;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.ProductServices.Commands
{
    public class ProductCommandService(
        IProductCommandRepository productCommandRepository, 
        IProductQueryRepository productQueryRepository
    ) : IProductCommandService
    {
        private readonly IProductCommandRepository _productCommandRepository = productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository = productQueryRepository;
        public async Task CreateProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                CategoryId = productDto.CategoryId,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Status = productDto.Status
            };

            await _productCommandRepository.CreateProductAsync(product);
        }

        public async Task UpdateProduct(ProductDto productDto, int id)
        {
            var product = await _productQueryRepository.GetProductByIdAsync(id);

            if (product == null)
                throw new KeyNotFoundException();

            product.Name = productDto.Name;
            product.CategoryId = productDto.CategoryId;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;
            product.Status = productDto.Status;
            product.IsDeleted = productDto.IsDeleted;

            await _productCommandRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProduct(int id)
        {
            if (id == 0)
                throw new KeyNotFoundException();

            await _productCommandRepository.DeleteProductAsync(id);
        }
    }
}
