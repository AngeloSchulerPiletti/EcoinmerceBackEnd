using AutoMapper;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;

namespace Ecoinmerce.Services.Mapper.AutoMapperProfiles;

public class EcommerceMappingProfiles : Profile
{
    public EcommerceMappingProfiles()
    {
        CreateMap<RegisterEcommerceDTO, Ecommerce>();
        CreateMap<RegisterManagerDTO, EcommerceManager>();
    }
}
