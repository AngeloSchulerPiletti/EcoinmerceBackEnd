using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Domain.Validators;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Application;

public class ApiCredentialBusiness : IApiCredentialBusiness
{
    private readonly IApiCredentialRepository _apiCredentialRepository;
    private readonly IEcommerceRepository _ecommerceRepository;
    private readonly ITokenServiceEcommerce _tokenServiceEcommerce;
    private readonly ApiCredentialSetting _apiCredentialSetting;

    public ApiCredentialBusiness(IApiCredentialRepository apiCredentialRepository,
                                 IEcommerceRepository ecommerceRepository,
                                 ITokenServiceEcommerce tokenServiceEcommerce,
                                 ApiCredentialSetting apiCredentialSetting)
    {
        _apiCredentialRepository = apiCredentialRepository;
        _ecommerceRepository = ecommerceRepository;
        _tokenServiceEcommerce = tokenServiceEcommerce;
        _apiCredentialSetting = apiCredentialSetting;
    }

    public MessageBagSingleEntityVO<ApiCredential> CreateApiCredential(Ecommerce ecommerce, ApiCredential apiCredential)
    {
        TokenVO token = _tokenServiceEcommerce.GenerateApiToken(ecommerce, (int)apiCredential.ValidityInDays);
        apiCredential.AccessToken = token.Token;
        apiCredential.AccessTokenExpiry = token.TokenData.ValidTo;

        ecommerce.ApiCredentials.Add(apiCredential);

        bool saveResult = _apiCredentialRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<ApiCredential>("Credencial criada com sucesso", "Sucesso", false, apiCredential) :
            new MessageBagSingleEntityVO<ApiCredential>("Tivemos um erro ao criar sua credencial", "Erro nosso!", true);
    }

    public MessageBagVO DeleteApiCredential(ApiCredential apiCredential)
    {
        _apiCredentialRepository.Delete(apiCredential);
        bool saveResult = _apiCredentialRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<ApiCredential>("Tivemos um erro e já estamos trabalhando para corrigí-lo", "Não foi possível deletar a credencial") :
            new MessageBagSingleEntityVO<ApiCredential>("Credencial deletada", "Sucesso");
    }

    public MessageBagSingleEntityVO<ApiCredential> GetApiCredentialById(int id)
    {
        ApiCredential apiCredential = _apiCredentialRepository.GetById(id);
        return apiCredential == null ?
            new MessageBagSingleEntityVO<ApiCredential>(null, "Credencial não existe") :
            new MessageBagSingleEntityVO<ApiCredential>("Credencial encontrada", "Sucesso", false, apiCredential);
    }

    public MessageBagListEntityVO<ApiCredential> GetApiCredentialsByEcommerceId(int ecommerceId)
    {
        List<ApiCredential> apiCredentials = _apiCredentialRepository.GetApiCredentialsByEcommerceId(ecommerceId);
        if (apiCredentials == null) return new MessageBagListEntityVO<ApiCredential>("Erro ao buscar credenciais", "Erro interno");

        MessageBagListEntityVO<ApiCredential> messageBagList = new("Credenciais encontradas", null, false);
        messageBagList.Entities.AddRange(apiCredentials);
        return messageBagList;
    }

    public MessageBagSingleEntityVO<ApiCredential> GetEcommerceApiCredentialById(Ecommerce ecommerce, int id)
    {
        ApiCredential apiCredential = ecommerce.ApiCredentials.FirstOrDefault(x => x.Id == id);
        return apiCredential == null ?
            new MessageBagSingleEntityVO<ApiCredential>("Essa credencial não é sua", "Credencial não encontrada") :
            new MessageBagSingleEntityVO<ApiCredential>("Credencial encontrada", "Sucesso", false, apiCredential);
    }

    public int GetMaxCredentials()
    {
        return _apiCredentialSetting.MaxCredentials;
    }

    public MessageBagSingleEntityVO<ApiCredential> RenewCredential(Ecommerce ecommerce, ApiCredential apiCredential)
    {
        TokenVO token = _tokenServiceEcommerce.GenerateApiToken(ecommerce, (int)apiCredential.ValidityInDays);
        apiCredential.AccessToken = token.Token;
        apiCredential.AccessTokenExpiry = token.TokenData.ValidTo;

        bool saveResult = _apiCredentialRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<ApiCredential>("Credencial renovada com sucesso", "Sucesso", false, apiCredential) :
            new MessageBagSingleEntityVO<ApiCredential>("Tivemos um erro ao renovar sua credencial", "Erro nosso!", true);
    }

    public MessageBagSingleEntityVO<ApiCredential> UpdateApiCredential(ApiCredential oldApiCredential, ApiCredential updateApiCredential)
    {
        oldApiCredential.ValidityInDays = updateApiCredential.ValidityInDays == null ;
        oldApiCredential.Name ??= updateApiCredential.Name;
        oldApiCredential.Description ??= updateApiCredential.Description;

        bool saveResult = _apiCredentialRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<ApiCredential>("Credencial atualizada", "Sucesso", false, oldApiCredential) :
            new MessageBagSingleEntityVO<ApiCredential>("Não foi possível atualizar a credencial", "Erro nosso!");
    }

    public MessageBagVO ValidateMaxCredentials(Ecommerce ecommerce)
    {
        return _ecommerceRepository.GetTotalApiCredentials(ecommerce.Id) >= _apiCredentialSetting.MaxCredentials ?
            new MessageBagVO("Número máximo de credenciais atingido", "Não é possível criar outra credencial") :
            new MessageBagVO(null, null, false);
    }

    public MessageBagVO ValidateNewApiCredential(ApiCredential apiCredential)
    {
        return GenericValidatorExecutor.ValidatorResultIterator(apiCredential, new NewApiCredentialValidator());
    }

    public MessageBagVO ValidateUpdateApiCredential(ApiCredential apiCredential)
    {
        return GenericValidatorExecutor.ValidatorResultIterator(apiCredential, new UpdateApiCredentialValidator());
    }
}
