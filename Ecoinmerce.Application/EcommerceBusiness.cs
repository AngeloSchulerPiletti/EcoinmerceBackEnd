using AutoMapper;
using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Domain.Validators;
using Ecoinmerce.Domain.Validators.Interfaces;
using Ecoinmerce.Infra.Repository.Interfaces;
using Ecoinmerce.Infra.Repository.Repositories;
using Ecoinmerce.Services.WalletManager;
using Ecoinmerce.Services.WalletManager.Interfaces;
using Microsoft.Extensions.Configuration;
using Nethereum.Web3.Accounts;

namespace Ecoinmerce.Application;

public class EcommerceBusiness : IEcommerceBusiness
{
    private readonly IMapper _mapper;
    private readonly IGenericValidatorExecutor _genericValidator;
    private readonly IEtherWalletRepository _etherWalletRepository;
    private readonly IEcommerceRepository _ecommerceRepository;
    private readonly IHdWalletManager _hdWalletManager;

    public EcommerceBusiness(IGenericValidatorExecutor genericValidator,
                             IHdWalletManager hdWalletManager,
                             IEcommerceRepository ecommerceRepository,
                             IEtherWalletRepository etherWalletRepository,
                             IMapper mapper)
    {
        _genericValidator = genericValidator;
        _ecommerceRepository = ecommerceRepository;
        _etherWalletRepository = etherWalletRepository;
        _hdWalletManager = hdWalletManager;
        _mapper = mapper;
    }

    public MessageBagSingleEntityVO<Ecommerce> Register(RegisterEcommerceDTO registerEcommerceDTO)
    {
        Ecommerce ecommerce = _mapper.Map<Ecommerce>(registerEcommerceDTO);

        EtherWallet wallet = CreateEtherWallet(registerEcommerceDTO);

        ecommerce.EtherWallets.Add(wallet);

        // Manda um email parabenizando por criar uma conta

        _ecommerceRepository.Insert(ecommerce);
        return new MessageBagSingleEntityVO<Ecommerce>("Ecommerce criado com sucesso", "Sucesso", false, ecommerce);
    }

    public MessageBagVO Validate(RegisterEcommerceDTO registerEcommerceDTO)
    {
        return _genericValidator.ValidatorResultIterator(registerEcommerceDTO, new RegisterEcommerceDTOValidator());
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
}
