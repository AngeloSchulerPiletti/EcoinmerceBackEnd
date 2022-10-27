using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Interfaces;

public interface IEcommerceBusiness
{
    public MessageBagSingleEntityVO<Ecommerce> MapToEntity(RegisterEcommerceDTO registerEcommerceDTO);
    public MessageBagVO Validate(RegisterEcommerceDTO registerEcommerceDTO);
}
