using AutoMapper;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.DTOs.EcommerceDTO;
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Interfaces;

public interface IEcommerceBusiness
{
    public MessageBagVO ConfirmEmail(string confirmationToken);
    public MessageBagSingleEntityVO<PublicEcommerce> GetPublicEcommerceById(int id);
    public MessageBagSingleEntityVO<Ecommerce> Register(RegisterEcommerceDTO registerEcommerceDTO);
    public void SendWelcomeEmailAsync(Ecommerce ecommerce);
    public MessageBagVO ValidateRegister(RegisterEcommerceDTO registerEcommerceDTO);
}
