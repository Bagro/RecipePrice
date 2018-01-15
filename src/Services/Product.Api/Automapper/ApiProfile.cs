using AutoMapper;
using Product.Api.Models;

namespace Product.Api.Automapper
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<ProductDto, Models.Product>();
            
            CreateMap<Models.Product, ProductDto>();
        }
    }
}