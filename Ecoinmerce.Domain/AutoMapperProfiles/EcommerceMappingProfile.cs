using AutoMapper;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTO.EcommerceDTO;

namespace Ecoinmerce.Domain.AutoMapperProfiles
{
    public class EcommerceMappingProfile : Profile
    {
        public EcommerceMappingProfile()
        {
            CreateMap<User, NewUserDTO>();
            CreateMap<NewUserDTO, User>();
            CreateMap<Ecommerce, NewEcommerceDTO>();
            CreateMap<NewEcommerceDTO, Ecommerce>();
            CreateMap<PublicUserDTO, User>();
            CreateMap<User, PublicUserDTO>();
        }
    }
}