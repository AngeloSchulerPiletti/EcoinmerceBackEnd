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
using Nethereum.Contracts.Standards.ERC20.TokenList;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;

namespace Ecoinmerce.Application;

public class EcommerceManagerBusiness : IEcommerceManagerBusiness
{
    private readonly IEcommerceManagerRepository _ecommerceManagerRepository;
    private readonly IEcommerceAdminRepository _ecommerceAdminRepository;
    private readonly ITokenServiceEcommerceManager _tokenServiceEcommerceManager;
    private readonly IGenericValidatorExecutor _genericValidator;
    private readonly IUserMail _mailService;
    private readonly IMapper _mapper;

    public EcommerceManagerBusiness(IEcommerceManagerRepository ecommerceManagerRepository,
                                    ITokenServiceEcommerceManager tokenServiceEcommerceManager,
                                    IEcommerceAdminRepository ecommerceAdminRepository,
                                    IUserMail mailService,
                                    IGenericValidatorExecutor genericValidator,
                                    IMapper mapper)
    {
        _mapper = mapper;
        _mailService = mailService;
        _ecommerceManagerRepository = ecommerceManagerRepository;
        _ecommerceAdminRepository = ecommerceAdminRepository;
        _tokenServiceEcommerceManager = tokenServiceEcommerceManager;
        _genericValidator = genericValidator;
    }

    public MessageBagSingleEntityVO<EcommerceManager> ChangePassword(EcommerceManager ecommerceManager, string nakedPassword)
    {
        MessageBagVO messageBagAuth = PasswordAndAuthTokensSet(ref ecommerceManager, nakedPassword);
        if (messageBagAuth.IsError) return MessageBagSingleEntityVO<EcommerceManager>.MapFromMessageBagVO(messageBagAuth);

        bool saveResult = _ecommerceManagerRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<EcommerceManager>("Senha alterada", "Sucesso", false, ecommerceManager) :
            new MessageBagSingleEntityVO<EcommerceManager>("Tivemos um erro interno ao salvar", "Desculpe!");
    }

    public MessageBagVO ConfirmEmail(string confirmationToken)
    {
        JwtSecurityToken token = _tokenServiceEcommerceManager.ValidateConfirmationToken(confirmationToken);
        if (token == null)
            return new MessageBagSingleEntityVO<EcommerceManager>("Token de confirmação inválido", "Não autorizado");

        string email = _tokenServiceEcommerceManager.GetEmailFromToken(confirmationToken).Value;
        if (email == null) return new MessageBagVO("Token de confirmação inválido", "Erro");

        EcommerceManager manager = _ecommerceManagerRepository.GetByEmail(email);
        if (manager == null) return new MessageBagVO("Token de confirmação inválido", "Erro");

        if (confirmationToken == null || confirmationToken != manager.ConfirmationToken)
            return new MessageBagVO("Token de confirmação inválido", "Erro");

        if (DateTime.Now > manager.ConfirmationTokenExpiry)
            return new MessageBagVO("Token de confirmação expirado", "Erro");

        manager.IsEmailConfirmed = true;
        manager.ConfirmationToken = null;
        manager.ConfirmationTokenExpiry = null;

        bool saveResult = _ecommerceManagerRepository.SaveChanges();
        return saveResult ?
            new MessageBagVO("Email confirmado", "Sucesso", false) :
            new MessageBagVO("Tivemos um erro interno, já estamos trabalhando nisso!", "Erro interno");
    }

    public MessageBagSingleEntityVO<EcommerceManager> GetManagerByConfirmationToken(string token)
    {
        Claim emailClaim = _tokenServiceEcommerceManager.GetEmailFromToken(token);
        if (emailClaim == null)
            return new MessageBagSingleEntityVO<EcommerceManager>("Token inválido", null);

        EcommerceManager manager = _ecommerceManagerRepository.GetByEmail(emailClaim.Value);
        return manager == null ?
            new MessageBagSingleEntityVO<EcommerceManager>("Token inválido", "Gerente não existe") :
            new MessageBagSingleEntityVO<EcommerceManager>("Gerente encontrado", null, false, manager);
    }

    public MessageBagSingleEntityVO<EcommerceManager> GetManagerByEmail(string email)
    {
        EcommerceManager manager = _ecommerceManagerRepository.GetByEmail(email);
        return manager == null ?
            new MessageBagSingleEntityVO<EcommerceManager>("Este email não está cadastrado", "Gerente não encontrado") :
            new MessageBagSingleEntityVO<EcommerceManager>(null, "Gerente encontrado", false, manager);
    }

    public bool IsUsernameUnavailable(string username)
    {
        return _ecommerceAdminRepository.AnyUsername(username) || _ecommerceManagerRepository.AnyUsername(username);
    }

    public MessageBagSingleEntityVO<EcommerceManager> Login(LoginDTO loginDTO)
    {
        if (loginDTO.Email == null || loginDTO.NakedPassword == null)
            return new MessageBagSingleEntityVO<EcommerceManager>("Preencha o email e a senha", "Erro no login");

        EcommerceManager manager = _ecommerceManagerRepository.GetByEmail(loginDTO.Email);
        if (manager == null)
            return new MessageBagSingleEntityVO<EcommerceManager>("Email não cadastrado", "Erro no login");

        string hashedPassword = _tokenServiceEcommerceManager.HashPassword(loginDTO.NakedPassword, manager.Salt);
        if (hashedPassword != manager.Password)
            return new MessageBagSingleEntityVO<EcommerceManager>("Senha inválida", "Erro no login");

        TokenVO accessTokenVO = _tokenServiceEcommerceManager.GenerateAccessToken(manager);
        manager.SetAccessToken(accessTokenVO);

        TokenVO refreshTokenVO = _tokenServiceEcommerceManager.GenerateRefreshToken(manager);
        manager.SetRefreshToken(refreshTokenVO);

        _ecommerceManagerRepository.SaveChangesAsync();

        return new MessageBagSingleEntityVO<EcommerceManager>("Login realizado com sucesso", "Sucesso", false, manager);
    }

    public MessageBagSingleEntityVO<EcommerceManager> RefreshAccessToken(string refreshToken)
    {
        JwtSecurityToken token = _tokenServiceEcommerceManager.ValidateRefreshToken(refreshToken);
        if (token == null)
            return new MessageBagSingleEntityVO<EcommerceManager>("Refresh Token inválido", "Não autorizado");

        string email = _tokenServiceEcommerceManager.GetEmailFromToken(refreshToken).Value;
        if (email == null)
            return new MessageBagSingleEntityVO<EcommerceManager>("Refresh Token inválido", "Não autorizado");

        EcommerceManager manager = _ecommerceManagerRepository.GetByEmail(email);
        if (manager == null)
            return new MessageBagSingleEntityVO<EcommerceManager>("Refresh Token inválido", "Não autorizado");

        if (refreshToken == null || refreshToken != manager.RefreshToken)
            return new MessageBagSingleEntityVO<EcommerceManager>("Refresh Token não é seu", "Não autorizado");

        if (DateTime.Now > manager.RefreshTokenExpiry)
            return new MessageBagSingleEntityVO<EcommerceManager>("Token expirado", "Erro");

        TokenVO tokenVO = _tokenServiceEcommerceManager.GenerateAccessToken(manager);
        manager.SetAccessToken(tokenVO);

        bool saveResult = _ecommerceManagerRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<EcommerceManager>("Access token atualizado", "Sucesso", false, manager) :
            new MessageBagSingleEntityVO<EcommerceManager>("Tivemos um erro interno ao salvar o token", "Desculpe!");
    }

    public MessageBagSingleEntityVO<EcommerceManager> Register(RegisterManagerDTO registerManagerDTO, Ecommerce ecommerce)
    {
        EcommerceManager ecommerceManager = _mapper.Map<EcommerceManager>(registerManagerDTO);

        ecommerceManager.Ecommerce = ecommerce;

        if (IsUsernameUnavailable(ecommerceManager.Username))
        {
            MessageBagSingleEntityVO<EcommerceManager> error = new("Informções inválidas", "Erro de cadastro", true);
            error.DictionaryMessages.Add("Username", "Outro usuários está utilizando esse username");
            return error;
        }

        MessageBagVO messageBagAuth = PasswordAndAuthTokensSet(ref ecommerceManager, registerManagerDTO.NakedPassword);
        if (messageBagAuth.IsError) return MessageBagSingleEntityVO<EcommerceManager>.MapFromMessageBagVO(messageBagAuth);

        SetupForEmailConfirmation(ecommerceManager);

        _ecommerceManagerRepository.Insert(ecommerceManager);
        bool saveResult = _ecommerceManagerRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<EcommerceManager>("Verifique seu email", "Cadastro realizado com sucesso!", false, ecommerceManager) :
            new MessageBagSingleEntityVO<EcommerceManager>("Tivemos um erro interno. Já estamos trabalhando nisso!", "Desculpe pelo incômodo");
    }

    public void SendConfirmationEmailAsync(EcommerceManager manager)
    {
        MailMessage mailMessage = new()
        {
            Subject = $"Bem vindo, {manager.FirstName}",
            Body = $"Test body - {manager.ConfirmationToken}",
        };
        mailMessage.To.Add(manager.Email);

        _mailService.SendMailAsync(mailMessage);
    }

    public void SendForgotPasswordEmailAsync(EcommerceManager manager)
    {
        MailMessage mailMessage = new()
        {
            Subject = $"Bem vindo, {manager.FirstName}",
            Body = $"Test body forgot password - {manager.ConfirmationToken}",
        };
        mailMessage.To.Add(manager.Email);

        _mailService.SendMailAsync(mailMessage);
    }

    public MessageBagVO SetupForEmailConfirmation(EcommerceManager manager, bool saveChanges = false)
    {
        TokenVO confirmationTokenVO = _tokenServiceEcommerceManager.GenerateConfirmationToken(manager);
        manager.SetConfirmationToken(confirmationTokenVO);

        if (saveChanges)
        {
            bool saveResult = _ecommerceManagerRepository.SaveChanges();
            return saveResult ?
                new MessageBagVO(null, "Email de confirmação gerado", false) :
                new MessageBagVO("Tivemos um erro interno. Já estamos trabalhando nisso!", "Desculpe pelo incômodo");
        }
        return new MessageBagVO(null, null, false);
    }

    public MessageBagVO ValidateRegister(RegisterManagerDTO registerManagerDTO)
    {
        return _genericValidator.ValidatorResultIterator(registerManagerDTO, new RegisterManagerDTOValidator(), "manager");
    }

    public MessageBagVO ValidateConfirmationToken(string token)
    {
        JwtSecurityToken securityToken = _tokenServiceEcommerceManager.ValidateConfirmationToken(token);
        return securityToken == null ?
             new MessageBagSingleEntityVO<EcommerceManager>("Token inválido", null) :
             new MessageBagSingleEntityVO<EcommerceManager>("Token válido", null, false);
    }

    public MessageBagVO ValidateForChangePassword(EcommerceManager manager)
    {
        return manager.IsEmailConfirmed == true ?
            new MessageBagVO("Senha pode ser alterada", null, false) :
            new MessageBagVO("Confirme o email primeiro", "Senha não pode ser altrerada");
    }

    public MessageBagVO ValidateForResendConfirmationEmail(EcommerceManager manager)
    {
        return manager.IsEmailConfirmed == true ?
             new MessageBagVO("Seu email já está confirmado", "Boa notícia!") :
             new MessageBagVO(null, null, false);
    }

    private MessageBagVO PasswordAndAuthTokensSet(ref EcommerceManager manager, string nakedPassword)
    {
        bool passwordHashResult = _tokenServiceEcommerceManager.HashPasswordWithNewSalt(ref manager, nakedPassword);
        if (!passwordHashResult) return new MessageBagVO("Tivemos um problema ao tratar sua senha", "Desculpe! Tivemos um erro");

        TokenVO accessTokenVO = _tokenServiceEcommerceManager.GenerateAccessToken(manager);
        manager.SetAccessToken(accessTokenVO);

        TokenVO refreshTokenVO = _tokenServiceEcommerceManager.GenerateRefreshToken(manager);
        manager.SetRefreshToken(refreshTokenVO);

        return new MessageBagVO(null, null, false);
    }
}

