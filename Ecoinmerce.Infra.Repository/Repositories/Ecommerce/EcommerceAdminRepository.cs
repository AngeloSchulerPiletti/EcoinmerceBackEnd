using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;
using Ecoinmerce.Infra.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository;

public class EcommerceAdminRepository : GenericRepository<EcommerceAdmin>, IEcommerceAdminRepository
{
    private readonly EcommerceContext _ecommerceContext;
    public EcommerceAdminRepository(EcommerceContext ecommerceContext, DbContext context) : base(context)
    {
        _ecommerceContext = ecommerceContext;
    }

    public EcommerceAdmin GetByEmail(string email)
    {
        return _ecommerceContext.EcommerceAdmins.FirstOrDefault(x => x.Email == email);
    }
}
