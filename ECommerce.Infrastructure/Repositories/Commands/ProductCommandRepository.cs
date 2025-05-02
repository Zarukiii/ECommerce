using ECommerce.Application.Interfaces.Commands;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task UpdateProductAsync(Product product)
        {
            _appDbContext.Products.Update(product);

            product.DateUpdated = DateTime.Now;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                throw new KeyNotFoundException();

            var productEntry = _appDbContext.Products.Entry(await product);

            productEntry.Property("isDeleted").CurrentValue = true;
            productEntry.Property("DateUpdated").CurrentValue = DateTime.Now;
            productEntry.Property("Status").CurrentValue = 4;

            await _appDbContext.SaveChangesAsync();
        }
    }
}
