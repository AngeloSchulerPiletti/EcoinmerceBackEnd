﻿using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Interfaces;

public interface IEcommerceManagerBusiness
{
    public MessageBagSingleEntityVO<EcommerceManager> Login(LoginDTO loginDTO);
}
