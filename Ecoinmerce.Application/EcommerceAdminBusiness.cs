using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Application.Services.Token;
using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Infra.Repository;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Application;

public class EcommerceAdminBusiness : IEcommerceAdminBusiness
{
    private readonly IEcommerceAdminRepository _ecommerceAdminRepository;
    private readonly ITokenServiceEcommerceAdmin _tokenServiceEcommerceAdmin;

    public EcommerceAdminBusiness(IEcommerceAdminRepository ecommerceAdminRepository, ITokenServiceEcommerceAdmin tokenServiceEcommerceAdmin)
    {
        _ecommerceAdminRepository = ecommerceAdminRepository;
        _tokenServiceEcommerceAdmin = tokenServiceEcommerceAdmin;
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
}
