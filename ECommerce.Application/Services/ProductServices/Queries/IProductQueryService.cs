using ECommerce.Application.Dto;

namespace ECommerce.Application.Services.ProductServices.Queries
{
    public interface IProductQueryService
    {
        public Task<IEnumerable<ProductDto>> GetAllProducts();
        public Task<ProductDto> GetProductById(int id);
    }
}
