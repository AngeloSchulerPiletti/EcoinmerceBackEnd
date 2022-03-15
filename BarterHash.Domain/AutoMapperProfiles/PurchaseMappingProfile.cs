using AutoMapper;
using BarterHash.Domain.Entities.Purchase;
using BarterHash.Domain.Objects.DTO;

namespace BarterHash.Domain.AutoMapperProfiles
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
