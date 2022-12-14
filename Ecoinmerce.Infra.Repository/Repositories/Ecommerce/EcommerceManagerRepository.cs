using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository;

public class EcommerceManagerRepository : GenericRepository<EcommerceManager>, IEcommerceManagerRepository
{
    private readonly EcommerceContext _ecommerceContext;
    public EcommerceManagerRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
    {
        _ecommerceContext = ecommerceContext;
    }

    public bool AnyUsername(string username)
    {
        return _ecommerceContext.EcommerceManagers.Where(x => x.Username == username).Any();
    }

    public EcommerceManager GetByEmail(string email)
    {
        return _ecommerceContext.EcommerceManagers.FirstOrDefault(x => x.Email == email);
    }
}
