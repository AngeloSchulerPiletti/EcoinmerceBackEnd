using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Interfaces;

public interface IApiCredentialBusiness
{
    public MessageBagSingleEntityVO<ApiCredential> CreateApiCredential(Ecommerce ecommerce, ApiCredential apiCredential);
    public int GetMaxCredentials();
    public MessageBagVO ValidateMaxCredentials(Ecommerce ecommerce);
    public MessageBagVO ValidateNewApiCredential(ApiCredential apiCredential);
}
