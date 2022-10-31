using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;
using Ecoinmerce.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository;

public class EcommerceAdminRepository : GenericRepository<EcommerceAdmin>, IEcommerceAdminRepository
{
    private readonly EcommerceContext _ecommerceContext;
    public EcommerceAdminRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
    {
        _ecommerceContext = ecommerceContext;
    }

    public bool AnyUsername(string username)
    {
        return _ecommerceContext.EcommerceAdmins.Where(x => x.Username == username).Any();
    }

    public EcommerceAdmin GetByEmail(string email)
    {
        return _ecommerceContext.EcommerceAdmins.FirstOrDefault(x => x.Email == email);
    }
}
