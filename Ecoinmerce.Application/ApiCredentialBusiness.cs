using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Domain.Validators;
using Ecoinmerce.Domain.Validators.Interfaces;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Application;

public class ApiCredentialBusiness : IApiCredentialBusiness
{
    private readonly IApiCredentialRepository _apiCredentialRepository;
    private readonly IEcommerceRepository _ecommerceRepository;
    private readonly ITokenServiceEcommerce _tokenServiceEcommerce;
    private readonly IGenericValidatorExecutor _genericValidatorExecutor;
    private readonly ApiCredentialSetting _apiCredentialSetting;

    public MessageBagSingleEntityVO<ApiCredential> CreateApiCredential(Ecommerce ecommerce, ApiCredential apiCredential)
    {
        TokenVO token = _tokenServiceEcommerce.GenerateApiToken(ecommerce, apiCredential.ValidityInDays);
        apiCredential.AccessToken = token.Token;
        apiCredential.AccessTokenExpiry = token.TokenData.ValidTo;

        ecommerce.ApiCredentials.Add(apiCredential);

        bool saveResult = _apiCredentialRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<ApiCredential>("Credencial criada com sucesso", "Sucesso", false, apiCredential) :
            new MessageBagSingleEntityVO<ApiCredential>("Tivemos um erro ao criar sua credencial", "Erro nosso!", true);
    }

    public int GetMaxCredentials()
    {
        return _apiCredentialSetting.MaxCredentials;
    }

    public MessageBagVO ValidateMaxCredentials(Ecommerce ecommerce)
    {
        return _ecommerceRepository.GetTotalApiCredentials(ecommerce.Id) >= _apiCredentialSetting.MaxCredentials ?
            new MessageBagVO("Número máximo de credenciais atingido", "Não é possível criar outra credencial") :
            new MessageBagVO(null, null, false);
    }

    public MessageBagVO ValidateNewApiCredential(ApiCredential apiCredential)
    {
        return _genericValidatorExecutor.ValidatorResultIterator(apiCredential, new NewApiCredentialValidator());
    }
}
