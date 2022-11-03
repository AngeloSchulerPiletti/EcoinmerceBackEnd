using AutoMapper;
using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Domain.Validators.Interfaces;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Application.Interfaces;

public interface IEcommerceAdminBusiness
{
    public MessageBagVO ConfirmEmail(string confirmationToken);
    public bool IsUsernameAvailable(string username);
    public MessageBagSingleEntityVO<EcommerceAdmin> Login(LoginDTO loginDTO);
    public MessageBagSingleEntityVO<EcommerceAdmin> RefreshAccessToken(string refreshToken);
}
