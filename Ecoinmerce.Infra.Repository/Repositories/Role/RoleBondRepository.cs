using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Infra.Repository.Repositories;

public class RoleBondRepository : GenericRepository<RoleBond>, IRoleBondRepository
{
    private readonly EcommerceContext _ecommerceContext;

    public RoleBondRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
    {
        _ecommerceContext = ecommerceContext;
    }
}
