using AutoMapper;
using ECommerce.Application.Dto;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Profiles.ProductProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
