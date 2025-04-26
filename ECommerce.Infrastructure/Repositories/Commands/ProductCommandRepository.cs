using ECommerce.Application.Interfaces.Commands;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data;

namespace ECommerce.Infrastructure.Repositories.Commands
{
    public class ProductCommandRepository(AppDbContext appDbContext) : IProductCommandRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task CreateProductAsync(Product product)
        {
            await _appDbContext.Products.AddAsync(product);

            await _appDbContext.SaveChangesAsync();
        }
    }
}
