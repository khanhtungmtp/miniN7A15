
using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Configuration
{
    public class AddAutoMapperProfilesConfig : Profile
    {
        public AddAutoMapperProfilesConfig()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductListDto, Product>().ReverseMap();
        }
    }
}