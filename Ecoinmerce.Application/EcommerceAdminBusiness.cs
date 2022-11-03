using AutoMapper;
using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Application.Services.Token;
using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Domain.Validators.Interfaces;
using Ecoinmerce.Infra.Repository;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Application;

public class EcommerceAdminBusiness : IEcommerceAdminBusiness
{
    private readonly IEcommerceManagerRepository _ecommerceManagerRepository;
    private readonly IEcommerceAdminRepository _ecommerceAdminRepository;
    private readonly ITokenServiceEcommerceAdmin _tokenServiceEcommerceAdmin;
    private readonly IMapper _mapper;
    private readonly IGenericValidatorExecutor _genericValidator;

    public EcommerceAdminBusiness(IEcommerceAdminRepository ecommerceAdminRepository,
                                  IEcommerceManagerRepository ecommerceManagerRepository,
                                  ITokenServiceEcommerceAdmin tokenServiceEcommerceAdmin,
                                  IMapper mapper,
                                  IGenericValidatorExecutor genericValidator)
    {
        _ecommerceAdminRepository = ecommerceAdminRepository;
        _ecommerceManagerRepository = ecommerceManagerRepository;
        _tokenServiceEcommerceAdmin = tokenServiceEcommerceAdmin;
        _mapper = mapper;
        _genericValidator = genericValidator;
    }

    public bool IsUsernameAvailable(string username)
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
        string email = _tokenServiceEcommerceAdmin.ValidateTokenAndGetClaim(refreshToken, "email");
        if (email == null)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Refresh Token inválido", "Não autorizado");

        EcommerceAdmin admin = _ecommerceAdminRepository.GetByEmail(email);
        if (admin == null)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Refresh Token inválido", "Não autorizado");

        if (refreshToken == null || refreshToken != admin.RefreshToken)
            return new MessageBagSingleEntityVO<EcommerceAdmin>("Refresh Token não é seu", "Não autorizado");

        TokenVO tokenVO = _tokenServiceEcommerceAdmin.GenerateAccessToken(admin);
        admin.SetAccessToken(tokenVO);

        bool saveResult = _ecommerceAdminRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<EcommerceAdmin>("Access token atualizado", "Sucesso", false, admin) :
            new MessageBagSingleEntityVO<EcommerceAdmin>("Tivemos um erro interno ao salvar o token", "Desculpe!");
    }
}
