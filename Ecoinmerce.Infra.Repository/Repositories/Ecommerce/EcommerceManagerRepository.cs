using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository.Interfaces;

public class EcommerceManagerRepository : GenericRepository<EcommerceManager>, IEcommerceManagerRepository
{
    private readonly EcommerceContext _ecommerceContext;
    public EcommerceManagerRepository(EcommerceContext ecommerceContext, DbContext context) : base(context)
    {
        _ecommerceContext = ecommerceContext;
    }

    public EcommerceManager GetByEmail(string email)
    {
        return _ecommerceContext.EcommerceManagers.FirstOrDefault(x => x.Email == email);
    }
}
