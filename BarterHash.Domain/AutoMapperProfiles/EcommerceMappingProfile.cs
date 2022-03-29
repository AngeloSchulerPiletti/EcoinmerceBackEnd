using AutoMapper;
using BarterHash.Domain.Entities.Ecommerce;
using BarterHash.Domain.Objects.DTO.Ecommerce;

namespace BarterHash.Domain.AutoMapperProfiles
{
    public class EcommerceMappingProfile : Profile
    {
        public EcommerceMappingProfile()
        {
            CreateMap<User, NewUserDTO>();
            CreateMap<NewUserDTO, User>();
            CreateMap<Ecommerce, NewEcommerceDTO>();
            CreateMap<NewEcommerceDTO, Ecommerce>();
        }
    }
}