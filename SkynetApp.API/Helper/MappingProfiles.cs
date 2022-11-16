using AutoMapper;
using SkynetApp.API.Dtos;
using SkynetApp.API.Entities;

namespace SkynetApp.API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
