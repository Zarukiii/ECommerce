using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Interfaces.Queries;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.ProductServices.Queries
{
    public class ProductQueryService(IProductQueryRepository queryRepository) : IProductQueryService
    {
        private readonly IProductQueryRepository _queryRepository = queryRepository;

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _queryRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _queryRepository.GetProductByIdAsync(id);
        }
    }
}
