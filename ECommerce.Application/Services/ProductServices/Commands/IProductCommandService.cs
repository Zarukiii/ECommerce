using ECommerce.Application.Dto;

namespace ECommerce.Application.Services.ProductServices.Commands
{
    public interface IProductCommandService
    {
        public Task CreateProduct(ProductDto productDto);
        public Task UpdateProduct(ProductDto productDto, int id);
        public Task DeleteProduct(int id);
    }
}
