using ECommerce.Application.Dto;

namespace ECommerce.Application.Services.ProductServices.Queries
{
    public interface IProductQueryService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int id);
        Task<IEnumerable<ProductDto>> GetActiveProducts();
    }
}
