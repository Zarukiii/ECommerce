using ECommerce.Application.Dto;

namespace ECommerce.Application.Services.ProductServices
{
    public interface IProductService
    {
        public Task CreateProduct(ProductDto productDto);
    }
}
