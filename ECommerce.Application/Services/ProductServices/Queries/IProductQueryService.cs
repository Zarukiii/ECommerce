using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.ProductServices.Queries
{
    public interface IProductQueryService
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProductById(int id);
    }
}
