using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTO.EcommerceDTO;
using Ecoinmerce.Domain.Objects.VO.Responses;

namespace Ecoinmerce.Domain.ValidatedMappers.Interfaces
{
    public interface IValidatedMappings
    {
        public MessageBagSingleEntityVO<User> MapUserWithValidation(NewUserDTO newUserDTO);
        public MessageBagSingleEntityVO<Ecommerce> MapEcommerceWithValidation(NewEcommerceDTO newEcommerceDTO);
    }
}
