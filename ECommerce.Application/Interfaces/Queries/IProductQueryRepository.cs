using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Queries
{
    public interface IProductQueryRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
    }
}
