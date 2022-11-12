using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Interfaces;

public interface IEcommerceManagerBusiness
{
    public MessageBagSingleEntityVO<EcommerceManager> ChangePassword(EcommerceManager ecommerceManager, string nakedPassword);
    public MessageBagVO ConfirmEmail(string confirmationToken);
    public MessageBagSingleEntityVO<EcommerceManager> GetManagerByConfirmationToken(string token);
    public MessageBagSingleEntityVO<EcommerceManager> GetManagerByEmail(string email);
    public MessageBagSingleEntityVO<EcommerceManager> Login(LoginDTO loginDTO);
    public MessageBagSingleEntityVO<EcommerceManager> RefreshAccessToken(string refreshToken);
    public MessageBagSingleEntityVO<EcommerceManager> Register(RegisterManagerDTO registerManagerDTO, Ecommerce ecommerce);
    public void SendConfirmationEmailAsync(EcommerceManager manager);
    public void SendForgotPasswordEmailAsync(EcommerceManager manager);
    public MessageBagVO SetupForEmailConfirmation(EcommerceManager manager, bool saveChanges = false);
    public MessageBagVO ValidateRegister(RegisterManagerDTO registerManagerDTO);
    public MessageBagVO ValidateConfirmationToken(string token);
    public MessageBagVO ValidateForResendConfirmationEmail(EcommerceManager manager);
    public MessageBagVO ValidateForChangePassword(EcommerceManager manager);
}
