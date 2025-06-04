using ECommerce.Application.Interfaces.Queries;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories.Queries
{
    public class ProductQueryRepository(AppDbContext appDbContext) : IProductQueryRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<IEnumerable<Product>> GetAllActiveAsync()
        {
            var products = await _appDbContext.Products
                .Where(p => p.IsDeleted != true)
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _appDbContext.Products.ToListAsync();

            return products;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            return product;
        }
    }
}
