using AutoMapper;
using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.DTOs.EcommerceDTO;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Domain.Validators;
using Ecoinmerce.Infra.MailService.Interfaces;
using Ecoinmerce.Infra.Repository.Interfaces;
using Ecoinmerce.Services.WalletManager.Interfaces;
using Nethereum.Web3.Accounts;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;

namespace Ecoinmerce.Application;

public class EcommerceBusiness : IEcommerceBusiness
{
    private readonly IMapper _mapper;
    private readonly IEtherWalletRepository _etherWalletRepository;
    private readonly IEcommerceRepository _ecommerceRepository;
    private readonly IHdWalletManager _hdWalletManager;
    private readonly IUserMail _mailService;
    private readonly ITokenServiceEcommerce _tokenServiceEcommerce;
    private const string _baseIdentifier = "registerEcommerce";

    public EcommerceBusiness(IHdWalletManager hdWalletManager,
                             IEcommerceRepository ecommerceRepository,
                             IEtherWalletRepository etherWalletRepository,
                             IUserMail mailService,
                             IMapper mapper,
                             ITokenServiceEcommerce tokenServiceEcommerce)
    {
        _ecommerceRepository = ecommerceRepository;
        _etherWalletRepository = etherWalletRepository;
        _hdWalletManager = hdWalletManager;
        _mailService = mailService;
        _mapper = mapper;
        _tokenServiceEcommerce = tokenServiceEcommerce;
    }
    public MessageBagVO ConfirmEmail(string confirmationToken)
    {
        JwtSecurityToken token = _tokenServiceEcommerce.ValidateConfirmationToken(confirmationToken);
        if (token == null) return new MessageBagVO("Token de confirmação inválido", "Erro");

        string email = _tokenServiceEcommerce.GetEmailFromToken(confirmationToken).Value;
        if (email == null) return new MessageBagVO("Token de confirmação inválido", "Erro");

        Ecommerce ecommerce = _ecommerceRepository.GetByEmail(email);
        if (ecommerce == null) return new MessageBagVO("Token de confirmação inválido", "Erro");

        if (confirmationToken == null || confirmationToken != ecommerce.ConfirmationToken)
            return new MessageBagVO("Token de confirmação inválido", "Erro");

        if (DateTime.Now > ecommerce.ConfirmationTokenExpiry)
            return new MessageBagVO("Token de confirmação expirado", "Erro");

        ecommerce.IsEmailConfirmed = true;
        ecommerce.ConfirmationToken = null;
        ecommerce.ConfirmationTokenExpiry = null;

        bool saveResult = _ecommerceRepository.SaveChanges();
        return saveResult ?
            new MessageBagVO("Email confirmado", "Sucesso", false) :
            new MessageBagVO("Tivemos um erro interno, já estamos trabalhando nisso!", "Erro interno");
    }

    public MessageBagSingleEntityVO<Ecommerce> Register(RegisterEcommerceDTO registerEcommerceDTO)
    {
        Ecommerce ecommerce = _mapper.Map<Ecommerce>(registerEcommerceDTO);

        EtherWallet wallet = CreateEtherWallet(registerEcommerceDTO);

        ecommerce.EtherWallets.Add(wallet);

        _ecommerceRepository.Insert(ecommerce);
        return new MessageBagSingleEntityVO<Ecommerce>("Ecommerce criado com sucesso", "Sucesso", false, ecommerce);
    }

    public void SendWelcomeEmailAsync(Ecommerce ecommerce)
    {
        MailMessage mailMessage = new()
        {
            Body = "Bem vindo! Esperamos poder ajudá-los nessa caminhada de aceitar cripto como pagamento",
            Subject = "Bem vindo à Web 3.0",
            From = new MailAddress("contato@ecoinmerce.com")
        };
        mailMessage.To.Add(ecommerce.Email);

        _mailService.SendMailAsync(mailMessage);
    }

    public MessageBagVO ValidateRegister(RegisterEcommerceDTO registerEcommerceDTO)
    {
        MessageBagVO messageBagBaseValidation = GenericValidatorExecutor.ValidatorResultIterator(registerEcommerceDTO, new RegisterEcommerceDTOValidator(), _baseIdentifier);
        if (messageBagBaseValidation.IsError) return messageBagBaseValidation;

        MessageBagVO messageBagCnpjValidation = ValidateUniqueCnpj(registerEcommerceDTO.Cnpj);
        if (messageBagCnpjValidation.IsError) return messageBagCnpjValidation;

        MessageBagVO messageBagEmailValidation = ValidateUniqueEmail(registerEcommerceDTO.Email);
        if (messageBagEmailValidation.IsError) return messageBagEmailValidation;

        messageBagBaseValidation.Messages.Add("Cnpj válido");
        messageBagBaseValidation.Messages.Add("Email válido");
        return messageBagBaseValidation;

    }

    private EtherWallet CreateEtherWallet(RegisterEcommerceDTO registerEcommerceDTO)
    {
        EtherWallet wallet;
        if (registerEcommerceDTO.WalletAddress == null)
        {
            Account account = _hdWalletManager.GetWalletAccount((int)(_etherWalletRepository.GetLastEtherWalletId() + 1));
            wallet = new()
            {
                Address = account.Address,
                PrivateKey = account.PrivateKey,
                PublicKey = account.PublicKey,
                Name = registerEcommerceDTO.WalletName,
                IsInternalCustody = true
            };
        }
        else
        {
            wallet = new()
            {
                Address = registerEcommerceDTO.WalletAddress,
                Name = registerEcommerceDTO.WalletName,
                IsInternalCustody = false
            };
        }
        return wallet;
    }
    private MessageBagVO ValidateUniqueCnpj(string cnpj)
    {
        MessageBagVO messageBag = new();
        if (_ecommerceRepository.CnpjIsBeingUsed(cnpj))
        {
            messageBag.DictionaryMessages.Add(_baseIdentifier, new Dictionary<string, List<string>>() { { "cnpj", new List<string>() { "Já está sendo usado" } } });
            return messageBag;
        }
        messageBag.IsError = false;
        return messageBag;
    }

    private MessageBagVO ValidateUniqueEmail(string email)
    {
        MessageBagVO messageBag = new();
        if (_ecommerceRepository.EmailIsBeingUsed(email))
        {
            messageBag.DictionaryMessages.Add(_baseIdentifier, new Dictionary<string, List<string>>() { { "email", new List<string>() { "Já está sendo usado" } } });
            return messageBag;
        }
        messageBag.IsError = false;
        return messageBag;
    }

    public MessageBagSingleEntityVO<PublicEcommerce> GetPublicEcommerceById(int id)
    {
        Ecommerce ecommerce = _ecommerceRepository.GetById(id);
        if (ecommerce == null)
            return new MessageBagSingleEntityVO<PublicEcommerce>("Não foi possível encontrar o ecommerce desse pagamento");

        PublicEcommerce publicEcommerce = new()
        {
            FantasyName = ecommerce.FantasyName,
            WalletAddress = ecommerce.EtherWallets[0].Address
        };
        return new MessageBagSingleEntityVO<PublicEcommerce>("Ecommerce encontrado", null, false, publicEcommerce);
    }

    public MessageBagSingleEntityVO<Ecommerce> GetEcommerceById(int id)
    {
        Ecommerce ecommerce = _ecommerceRepository.GetById(id);
        return ecommerce == null ?
            new MessageBagSingleEntityVO<Ecommerce>("Não foi possível encontrar o ecommerce. Tente mais tarde") :
            new MessageBagSingleEntityVO<Ecommerce>("Ecommerce encontrado", null, false, ecommerce);
    }
}
