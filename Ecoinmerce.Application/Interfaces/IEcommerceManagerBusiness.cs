using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Interfaces;

public interface IEcommerceManagerBusiness
{
    public MessageBagSingleEntityVO<EcommerceManager> Login(LoginDTO loginDTO);
    public MessageBagSingleEntityVO<EcommerceManager> MapToEntity(RegisterManagerDTO registerManagerDTO);
    public MessageBagVO Validate(RegisterManagerDTO registerManagerDTO);
}
