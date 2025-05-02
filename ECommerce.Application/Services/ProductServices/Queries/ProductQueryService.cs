using AutoMapper;
using ECommerce.Application.Dto;
using ECommerce.Application.Interfaces.Queries;

namespace ECommerce.Application.Services.ProductServices.Queries
{
    public class ProductQueryService(
        IProductQueryRepository queryRepository,
        IMapper mapper
        ) : IProductQueryService
    {
        private readonly IProductQueryRepository _queryRepository = queryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _queryRepository.GetAllProductsAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productsDto;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _queryRepository.GetProductByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }
    }
}
