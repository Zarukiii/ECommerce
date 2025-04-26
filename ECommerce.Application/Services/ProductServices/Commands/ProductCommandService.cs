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
                ParentCategoryId = productDto.ParentCat,
                SubCategoryId = productDto.SubCat,
                Price = productDto.Price,
                StockQuantity = productDto.Stock,
                ImageUrl = productDto.ImageUrl,
                Status = productDto.Status
            };

            await _productCommandRepository.CreateProductAsync(product);
        }

        public async Task UpdateProduct(ProductDto productDto, int id)
        {
            var product = await _productQueryRepository.GetProductById(id);

            if (product == null)
            {
                throw new KeyNotFoundException();
            }

            product.Name = productDto.Name;
            product.ParentCategoryId = productDto.ParentCat;
            product.SubCategoryId = productDto.SubCat;
            product.Price = productDto.Price;
            product.StockQuantity = productDto.Stock;
            product.ImageUrl = productDto.ImageUrl;
            product.Status = productDto.Status;

            await _productCommandRepository.UpdateProductAsync(product);
        }
    }
}
