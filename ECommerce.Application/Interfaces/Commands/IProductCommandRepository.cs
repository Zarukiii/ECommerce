using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Commands
{
    public interface IProductCommandRepository
    {
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
