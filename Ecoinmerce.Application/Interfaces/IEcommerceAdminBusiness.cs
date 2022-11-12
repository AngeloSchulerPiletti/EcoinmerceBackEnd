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
    public MessageBagSingleEntityVO<EcommerceAdmin> ChangePassword(EcommerceAdmin ecommerceAdmin, string nakedPassword);
    public MessageBagVO ConfirmEmail(string confirmationToken);
    public MessageBagSingleEntityVO<EcommerceAdmin> GetAdminByConfirmationToken(string token);
    public MessageBagSingleEntityVO<EcommerceAdmin> GetAdminByEmail(string email);
    public bool IsUsernameAvailable(string username);
    public MessageBagSingleEntityVO<EcommerceAdmin> Login(LoginDTO loginDTO);
    public MessageBagSingleEntityVO<EcommerceAdmin> RefreshAccessToken(string refreshToken);
    //public MessageBagSingleEntityVO<EcommerceAdmin> Register(RegisterAdminDTO registerAdminDTO, Ecommerce ecommerce);
    public void SendConfirmationEmailAsync(EcommerceAdmin admin);
    public void SendForgotPasswordEmailAsync(EcommerceAdmin admin);
    public MessageBagVO SetupForEmailConfirmation(EcommerceAdmin admin, bool saveChanges = false);
    //public MessageBagVO Validate(RegisterAdminDTO registerAdminDTO);
    public MessageBagVO ValidateConfirmationToken(string token);
    public MessageBagVO ValidateForResendConfirmationEmail(EcommerceAdmin admin);
    public MessageBagVO ValidateForChangePassword(EcommerceAdmin admin);
}
