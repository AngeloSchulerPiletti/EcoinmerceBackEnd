using AutoMapper;
using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Domain.Validators;
using Ecoinmerce.Domain.Validators.Interfaces;
using Ecoinmerce.Infra.MailService.Interfaces;
using Ecoinmerce.Infra.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;

namespace Ecoinmerce.Application;

public class EcommerceAdminBusiness : IEcommerceAdminBusiness
{
    private readonly IEcommerceManagerRepository _ecommerceManagerRepository;
    private readonly IEcommerceAdminRepository _ecommerceAdminRepository;
    private readonly ITokenServiceEcommerceAdmin _tokenServiceEcommerceAdmin;
    private readonly IMapper _mapper;
    private readonly IUserMail _mailService;
    private readonly IGenericValidatorExecutor _genericValidator;

    public EcommerceAdminBusiness(IEcommerceAdminRepository ecommerceAdminRepository,
                                  IEcommerceManagerRepository ecommerceManagerRepository,
                                  ITokenServiceEcommerceAdmin tokenServiceEcommerceAdmin,
                                  IMapper mapper,
                                  IUserMail mailService,
                                  IGenericValidatorExecutor genericValidator)
    {
        _ecommerceAdminRepository = ecommerceAdminRepository;
        _ecommerceManagerRepository = ecommerceManagerRepository;
        _tokenServiceEcommerceAdmin = tokenServiceEcommerceAdmin;
        _mapper = mapper;
        _mailService = mailService;
        _genericValidator = genericValidator;
    }

    public MessageBagSingleEntityVO<EcommerceAdmin> ChangePassword(EcommerceAdmin ecommerceAdmin, string nakedPassword)
    {
        MessageBagVO messageBagAuth = PasswordAndAuthTokensSet(ref ecommerceAdmin, nakedPassword);
        if (messageBagAuth.IsError) return MessageBagSingleEntityVO<EcommerceAdmin>.MapFromMessageBagVO(messageBagAuth);

        bool saveResult = _ecommerceAdminRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<EcommerceAdmin>("Senha alterada", "Sucesso", false, ecommerceAdmin) :
            new MessageBagSingleEntityVO<EcommerceAdmin>("Tivemos um erro interno ao salvar", "Desculpe!");
    }

    public MessageBagVO ConfirmEmail(string confirmationToken)
    {
        JwtSecurityToken token = _tokenServiceEcommerceAdmin.ValidateConfirmationToken(confirmationToken);
        if (token == null) return new MessageBagVO("Token de confirmação inválido", "Erro");

        string email = _tokenServiceEcommerceAdmin.GetEmailFromToken(confirmationToken).Value;
        if (email == null) return new MessageBagVO("Token de confirmação inválido", "Erro");

        EcommerceAdmin admin = _ecommerceAdminRepository.GetByEmail(email);
        if (admin == null) return new MessageBagVO("Token de confirmação inválido", "Erro");

        if (confirmationToken == null || confirmationToken != admin.ConfirmationToken)
            return new MessageBagVO("Token de confirmação inválido", "Erro");

        if (DateTime.Now > admin.ConfirmationTokenExpiry)
            return new MessageBagVO("Token de confirmação expirado", "Erro");

        admin.IsEmailConfirmed = true;
        admin.ConfirmationToken = null;
        admin.ConfirmationTokenExpiry = null;

        bool saveResult = _ecommerceAdminRepository.SaveChanges();
        return saveResult ?
            new MessageBagVO("Email confirmado", "Sucesso", false) :
            new MessageBagVO("Tivemos um erro interno, já estamos trabalhando nisso!", "Erro interno");

    }

    public MessageBagSingleEntityVO<EcommerceAdmin> GetAdminByConfirmationToken(string token)
    {
        Claim emailClaim = _tokenServiceEcommerceAdmin.GetEmailFromToken(token);
        if (emailClaim == null)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Token inválido", null);

        EcommerceAdmin admin = _ecommerceAdminRepository.GetByEmail(emailClaim.Value);
        return admin == null ?
            new MessageBagSingleEntityVO<EcommerceAdmin>("Token inválido", "Gerente não existe") :
            new MessageBagSingleEntityVO<EcommerceAdmin>("Administrador encontrado", null, false, admin);
    }

    public MessageBagSingleEntityVO<EcommerceAdmin> GetAdminByEmail(string email)
    {
        EcommerceAdmin admin = _ecommerceAdminRepository.GetByEmail(email);
        return admin == null ?
            new MessageBagSingleEntityVO<EcommerceAdmin>("Este email não está cadastrado", "Gerente não encontrado") :
            new MessageBagSingleEntityVO<EcommerceAdmin>(null, "Administrador encontrado", false, admin);
    }

    public bool IsUsernameUnavailable(string username)
    {
        return _ecommerceAdminRepository.AnyUsername(username) || _ecommerceManagerRepository.AnyUsername(username);
    }

    public MessageBagSingleEntityVO<EcommerceAdmin> Login(LoginDTO loginDTO)
    {
        if (loginDTO.Email == null || loginDTO.NakedPassword == null)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Preencha o email e a senha", "Erro no login");

        EcommerceAdmin admin = _ecommerceAdminRepository.GetByEmail(loginDTO.Email);
        if (admin == null)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Email não cadastrado", "Erro no login");

        string hashedPassword = _tokenServiceEcommerceAdmin.HashPassword(loginDTO.NakedPassword, admin.Salt);
        if (hashedPassword != admin.Password)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Senha inválida", "Erro no login");

        TokenVO accessTokenVO = _tokenServiceEcommerceAdmin.GenerateAccessToken(admin);
        admin.SetAccessToken(accessTokenVO);

        TokenVO refreshTokenVO = _tokenServiceEcommerceAdmin.GenerateRefreshToken(admin);
        admin.SetRefreshToken(refreshTokenVO);

        _ecommerceAdminRepository.SaveChangesAsync();

        return new MessageBagSingleEntityVO<EcommerceAdmin>("Login realizado com sucesso", "Sucesso", false, admin);
    }

    public MessageBagSingleEntityVO<EcommerceAdmin> RefreshAccessToken(string refreshToken)
    {
        JwtSecurityToken token = _tokenServiceEcommerceAdmin.ValidateRefreshToken(refreshToken);
        if(token == null)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Refresh Token inválido", "Não autorizado");

        string email = _tokenServiceEcommerceAdmin.GetEmailFromToken(refreshToken).Value;
        if (email == null)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Refresh Token inválido", "Não autorizado");

        EcommerceAdmin admin = _ecommerceAdminRepository.GetByEmail(email);
        if (admin == null)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Refresh Token inválido", "Não autorizado");

        if (refreshToken == null || refreshToken != admin.RefreshToken)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Refresh Token não é seu", "Não autorizado");

        if (DateTime.Now > admin.RefreshTokenExpiry)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Token expirado", "Erro");

        TokenVO tokenVO = _tokenServiceEcommerceAdmin.GenerateAccessToken(admin);
        admin.SetAccessToken(tokenVO);

        bool saveResult = _ecommerceAdminRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<EcommerceAdmin>("Access token atualizado", "Sucesso", false, admin) :
            new MessageBagSingleEntityVO<EcommerceAdmin>("Tivemos um erro interno ao salvar o token", "Desculpe!");
    }

    public MessageBagSingleEntityVO<EcommerceAdmin> Register(EcommerceAdmin registerEcommerceAdmin, Ecommerce ecommerce)
    {
        registerEcommerceAdmin.Ecommerce = ecommerce;

        if (IsUsernameUnavailable(registerEcommerceAdmin.Username))
        {
            MessageBagSingleEntityVO<EcommerceAdmin> error = new("Informções inválidas", "Erro de cadastro", true);
            error.DictionaryMessages.Add("username", "Outro usuários está utilizando esse username");
            return error;
        }

        MessageBagVO messageBagAuth = PasswordAndAuthTokensSet(ref registerEcommerceAdmin, registerEcommerceAdmin.GetNakedPassword());
        if (messageBagAuth.IsError) return MessageBagSingleEntityVO<EcommerceAdmin>.MapFromMessageBagVO(messageBagAuth);

        SetupForEmailConfirmation(registerEcommerceAdmin);

        _ecommerceAdminRepository.Insert(registerEcommerceAdmin);
        bool saveResult = _ecommerceAdminRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<EcommerceAdmin>("Verifique seu email", "Cadastro realizado com sucesso!", false, registerEcommerceAdmin) :
            new MessageBagSingleEntityVO<EcommerceAdmin>("Tivemos um erro interno. Já estamos trabalhando nisso!", "Desculpe pelo incômodo");
    }

    public void SendConfirmationEmailAsync(EcommerceAdmin admin)
    {
        MailMessage mailMessage = new()
        {
            Subject = $"Bem vindo, {admin.FirstName}",
            Body = $"Test body - {admin.ConfirmationToken}",
        };
        mailMessage.To.Add(admin.Email);

        _mailService.SendMailAsync(mailMessage);
    }

    public void SendForgotPasswordEmailAsync(EcommerceAdmin admin)
    {
        MailMessage mailMessage = new()
        {
            Subject = $"Bem vindo, {admin.FirstName}",
            Body = $"Test body forgot password - {admin.ConfirmationToken}",
        };
        mailMessage.To.Add(admin.Email);

        _mailService.SendMailAsync(mailMessage);
    }

    public MessageBagVO SetupForEmailConfirmation(EcommerceAdmin admin, bool saveChanges = false)
    {
        TokenVO confirmationTokenVO = _tokenServiceEcommerceAdmin.GenerateConfirmationToken(admin);
        admin.SetConfirmationToken(confirmationTokenVO);

        if (saveChanges)
        {
            bool saveResult = _ecommerceAdminRepository.SaveChanges();
            return saveResult ?
                new MessageBagVO(null, "Email de confirmação gerado", false) :
                new MessageBagVO("Tivemos um erro interno. Já estamos trabalhando nisso!", "Desculpe pelo incômodo");
        }
        return new MessageBagVO(null, null, false);
    }

    public MessageBagVO ValidateConfirmationToken(string token)
    {
        JwtSecurityToken securityToken = _tokenServiceEcommerceAdmin.ValidateConfirmationToken(token);
        return securityToken == null ?
             new MessageBagSingleEntityVO<EcommerceAdmin>("Token inválido", null) :
             new MessageBagSingleEntityVO<EcommerceAdmin>("Token válido", null, false);
    }

    public MessageBagVO ValidateForChangePassword(EcommerceAdmin admin)
    {
        return admin.IsEmailConfirmed == true ?
            new MessageBagVO("Senha pode ser alterada", null, false) :
            new MessageBagVO("Confirme o email primeiro", "Senha não pode ser altrerada");
    }

    public MessageBagVO ValidateForResendConfirmationEmail(EcommerceAdmin admin)
    {
        return admin.IsEmailConfirmed == true ?
             new MessageBagVO("Seu email já está confirmado", "Boa notícia!") :
             new MessageBagVO(null, null, false);
    }

    public MessageBagVO ValidateRegister(EcommerceAdmin admin)
    {
        return _genericValidator.ValidatorResultIterator(admin, new NewAdminValidator());
    }

    private MessageBagVO PasswordAndAuthTokensSet(ref EcommerceAdmin admin, string nakedPassword)
    {
        bool passwordHashResult = _tokenServiceEcommerceAdmin.HashPasswordWithNewSalt(ref admin, nakedPassword);
        if (!passwordHashResult) return new MessageBagVO("Tivemos um problema ao tratar sua senha", "Desculpe! Tivemos um erro");

        TokenVO accessTokenVO = _tokenServiceEcommerceAdmin.GenerateAccessToken(admin);
        admin.SetAccessToken(accessTokenVO);

        TokenVO refreshTokenVO = _tokenServiceEcommerceAdmin.GenerateRefreshToken(admin);
        admin.SetRefreshToken(refreshTokenVO);

        return new MessageBagVO(null, null, false);
    }
}
