﻿using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Interfaces;

public interface IEcommerceManagerBusiness
{
    public MessageBagVO ConfirmEmail(string confirmationToken);
    public MessageBagSingleEntityVO<EcommerceManager> Login(LoginDTO loginDTO);
    public MessageBagSingleEntityVO<EcommerceManager> RefreshAccessToken(string refreshToken);
    public MessageBagSingleEntityVO<EcommerceManager> Register(RegisterManagerDTO registerManagerDTO, Ecommerce ecommerce);
    public void SendConfirmationEmailAsync(EcommerceManager manager);
    public MessageBagVO Validate(RegisterManagerDTO registerManagerDTO);
}
