using AutoMapper;
using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Domain.Validators;
using Ecoinmerce.Domain.Validators.Interfaces;
using Ecoinmerce.Infra.MailService.Interfaces;
using Ecoinmerce.Infra.Repository.Interfaces;
using Ecoinmerce.Services.WalletManager.Interfaces;
using Nethereum.Web3.Accounts;
using System.Net.Mail;

namespace Ecoinmerce.Application;

public class EcommerceBusiness : IEcommerceBusiness
{
    private readonly IMapper _mapper;
    private readonly IGenericValidatorExecutor _genericValidator;
    private readonly IEtherWalletRepository _etherWalletRepository;
    private readonly IEcommerceRepository _ecommerceRepository;
    private readonly IHdWalletManager _hdWalletManager;
    private readonly IUserMail _mailService;

    public EcommerceBusiness(IGenericValidatorExecutor genericValidator,
                             IHdWalletManager hdWalletManager,
                             IEcommerceRepository ecommerceRepository,
                             IEtherWalletRepository etherWalletRepository,
                             IUserMail mailService,
                             IMapper mapper)
    {
        _genericValidator = genericValidator;
        _ecommerceRepository = ecommerceRepository;
        _etherWalletRepository = etherWalletRepository;
        _hdWalletManager = hdWalletManager;
        _mailService = mailService;
        _mapper = mapper;
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
            Subject = "Bem vindo à Web 3.0"
        };
        mailMessage.To.Add(ecommerce.Email);

        _mailService.SendMailAsync(mailMessage);
    }

    public MessageBagVO Validate(RegisterEcommerceDTO registerEcommerceDTO)
    {
        MessageBagVO messageBagBaseValidation = _genericValidator.ValidatorResultIterator(registerEcommerceDTO, new RegisterEcommerceDTOValidator());
        if (messageBagBaseValidation.IsError) return messageBagBaseValidation;

        MessageBagVO messageBagCnpjValidation = ValidateUniqueCnpj(registerEcommerceDTO.Cnpj);
        if(messageBagCnpjValidation.IsError) return messageBagCnpjValidation;

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
                Name = registerEcommerceDTO.WalletName
            };
        }
        else
        {
            wallet = new()
            {
                Address = registerEcommerceDTO.WalletAddress,
                Name = registerEcommerceDTO.WalletName
            };
        }
        return wallet;
    }
    private MessageBagVO ValidateUniqueCnpj(string cnpj)
    {
        MessageBagVO messageBag = new();
        if (_ecommerceRepository.CnpjIsBeingUsed(cnpj))
        {
            messageBag.DictionaryMessages.Add("cnpj", "Já está sendo usado");
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
            messageBag.DictionaryMessages.Add("email", "Já está sendo usado");
            return messageBag;
        }
        messageBag.IsError = false;
        return messageBag;
    }
}
