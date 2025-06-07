using ECommerce.Application.Interfaces.Commands;
using ECommerce.Application.Interfaces.Queries;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data;

namespace ECommerce.Infrastructure.Repositories.Commands
{
    public class ProductCommandRepository(
        AppDbContext appDbContext,
        IProductQueryRepository queryRepository
    ) : IProductCommandRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        private readonly IProductQueryRepository _queryRepository = queryRepository;

        public async Task CreateProductAsync(Product product)
        {
            await _appDbContext.Products.AddAsync(product);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _appDbContext.Products.Update(product);

            product.DateUpdated = DateTime.Now;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _queryRepository.GetProductByIdAsync(id);

            if (product == null)
                throw new KeyNotFoundException();

            var productEntry = _appDbContext.Products.Entry(product);

            productEntry.Property("IsDeleted").CurrentValue = true;
            productEntry.Property("DateUpdated").CurrentValue = DateTime.Now;
            productEntry.Property("Status").CurrentValue = 4;

            await _appDbContext.SaveChangesAsync();
        }
    }
}
