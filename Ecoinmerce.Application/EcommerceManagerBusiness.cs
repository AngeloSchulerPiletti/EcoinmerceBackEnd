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
using System.Net.Mail;

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

    public bool IsUsernameAvailable(string username)
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

    public MessageBagSingleEntityVO<EcommerceManager> Register(RegisterManagerDTO registerManagerDTO, Ecommerce ecommerce)
    {
        EcommerceManager ecommerceManager = _mapper.Map<EcommerceManager>(registerManagerDTO);

        ecommerceManager.Ecommerce = ecommerce;

        if (!IsUsernameAvailable(ecommerceManager.Username))
        {
            MessageBagSingleEntityVO<EcommerceManager> error = new("Informções inválidas", "Erro de cadastro", true);
            error.DictionaryMessages.Add("Username", "Outro usuários está utilizando esse username");
            return error;
        }

        bool passwordHashResult = _tokenServiceEcommerceManager.HashPasswordWithNewSalt(ref ecommerceManager, registerManagerDTO.NakedPassword);
        if (!passwordHashResult) return new MessageBagSingleEntityVO<EcommerceManager>("Tivemos um problema ao tratar sua senha", "Desculpe! Tivemos um erro");

        TokenVO accessTokenVO = _tokenServiceEcommerceManager.GenerateAccessToken(ecommerceManager);
        ecommerceManager.SetAccessToken(accessTokenVO);

        TokenVO refreshTokenVO = _tokenServiceEcommerceManager.GenerateRefreshToken(ecommerceManager);
        ecommerceManager.SetRefreshToken(refreshTokenVO);

        TokenVO confirmationTokenVO = _tokenServiceEcommerceManager.GenerateConfirmationToken(ecommerceManager);
        ecommerceManager.SetConfirmationToken(confirmationTokenVO);

        _ecommerceManagerRepository.Insert(ecommerceManager);
        bool saveResult = _ecommerceManagerRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<EcommerceManager>(null, "Cadastro realizado com sucesso!", false, ecommerceManager) :
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

    public MessageBagVO Validate(RegisterManagerDTO registerManagerDTO)
    {
        return _genericValidator.ValidatorResultIterator(registerManagerDTO, new RegisterManagerDTOValidator());
    }
}
