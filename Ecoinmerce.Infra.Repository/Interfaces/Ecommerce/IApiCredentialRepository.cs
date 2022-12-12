using Ecoinmerce.Domain.Entities;

namespace Ecoinmerce.Infra.Repository.Interfaces;

public interface IApiCredentialRepository : IGenericRepository<ApiCredential>
{
    public List<ApiCredential> GetApiCredentialsByEcommerceId(int ecommerceId);
}
