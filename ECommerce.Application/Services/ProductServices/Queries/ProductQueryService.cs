using ECommerce.Application.Dto;
using ECommerce.Application.Interfaces.Queries;

namespace ECommerce.Application.Services.ProductServices.Queries
{
    public class ProductQueryService(
        IProductQueryRepository queryRepository
    ) : IProductQueryService
    {
        private readonly IProductQueryRepository _queryRepository = queryRepository;

        public async Task<IEnumerable<ProductDto>> GetActiveProducts()
        {
            var activeProducts = await _queryRepository.GetAllActiveAsync();

            var activeProductsDto = activeProducts.Select(
                product => new ProductDto
                {
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Price = product.Price,
                    Stock = product.Stock,
                    Status = product.Status,
                });

            return activeProductsDto;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _queryRepository.GetAllProductsAsync();

            var productsDto = products.Select(
                product => new ProductDto
                {
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Price = product.Price,
                    Stock = product.Stock,
                    Status = product.Status,
                });

            return productsDto;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _queryRepository.GetProductByIdAsync(id);

            ProductDto productDto = new ProductDto
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Stock = product.Stock,
                Status = product.Status,
            };

            return productDto;
        }
    }
}
