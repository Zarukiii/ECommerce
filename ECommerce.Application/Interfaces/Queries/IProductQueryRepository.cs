using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Queries
{
    public interface IProductQueryRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
    }
}
