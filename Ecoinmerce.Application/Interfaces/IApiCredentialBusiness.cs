using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Interfaces;

public interface IApiCredentialBusiness
{
    public MessageBagSingleEntityVO<ApiCredential> CreateApiCredential(Ecommerce ecommerce, ApiCredential apiCredential);
    public MessageBagVO DeleteApiCredential(ApiCredential apiCredential);
    public MessageBagSingleEntityVO<ApiCredential> GetApiCredentialById(int id);
    public MessageBagListEntityVO<ApiCredential> GetApiCredentialsByEcommerceId(int ecommerceId);
    public MessageBagSingleEntityVO<ApiCredential> GetEcommerceApiCredentialById(Ecommerce ecommerce, int id);
    public int GetMaxCredentials();
    public MessageBagSingleEntityVO<ApiCredential> RenewCredential(Ecommerce ecommerce, ApiCredential apiCredential);
    public MessageBagSingleEntityVO<ApiCredential> UpdateApiCredential(ApiCredential oldApiCredential, ApiCredential updateApiCredential);
    public MessageBagVO ValidateMaxCredentials(Ecommerce ecommerce);
    public MessageBagVO ValidateNewApiCredential(ApiCredential apiCredential);
    public MessageBagVO ValidateUpdateApiCredential(ApiCredential apiCredential);
}
