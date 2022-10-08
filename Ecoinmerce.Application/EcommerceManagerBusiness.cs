using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Application;

public class EcommerceManagerBusiness : IEcommerceManagerBusiness
{
    private readonly IEcommerceManagerRepository _ecommerceManagerRepository;
    private readonly ITokenServiceEcommerceManager _tokenServiceEcommerceManager;

    public EcommerceManagerBusiness(IEcommerceManagerRepository ecommerceManagerRepository, ITokenServiceEcommerceManager tokenServiceEcommerceManager)
    {
        _ecommerceManagerRepository = ecommerceManagerRepository;
        _tokenServiceEcommerceManager = tokenServiceEcommerceManager;
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
}
