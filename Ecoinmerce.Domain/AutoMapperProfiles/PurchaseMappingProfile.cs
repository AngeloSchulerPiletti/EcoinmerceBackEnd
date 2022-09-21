using AutoMapper;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTO.PurchaseDTO;

namespace Ecoinmerce.Domain.AutoMapperProfiles
{
    public class PurchaseMappingProfile : Profile
    {
        public PurchaseMappingProfile()
        {
            CreateMap<Purchase, PaymentEventDTO>();
            CreateMap<PaymentEventDTO, Purchase>();
            CreateMap<PurchaseEventFailDTO, PurchaseEventFail>();
            CreateMap<PurchaseEventFail, PurchaseEventFailDTO>();
        }
    }
}
