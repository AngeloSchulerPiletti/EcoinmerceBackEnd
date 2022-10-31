using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Infra.Repository;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    private readonly EcommerceContext _ecommerceContext;

    public RoleRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
    {
        _ecommerceContext = ecommerceContext;
    }
}
