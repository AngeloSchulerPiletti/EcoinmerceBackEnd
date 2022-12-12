using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Infra.Repository;

public class ApiCredentialRepository : GenericRepository<ApiCredential>, IApiCredentialRepository
{
    private readonly EcommerceContext _ecommerceContext;

    public ApiCredentialRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
    {
        _ecommerceContext = ecommerceContext;
    }

    public List<ApiCredential> GetApiCredentialsByEcommerceId(int ecommerceId)
    {
        return _ecommerceContext.ApiCredentials.Where(x => x.EcommerceId == ecommerceId).ToList();
    }
}
