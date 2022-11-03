using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository;

public class EcommerceRepository : GenericRepository<Ecommerce>, IEcommerceRepository
{
    private readonly EcommerceContext _ecommerceContext;

    public EcommerceRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
    {
        _ecommerceContext = ecommerceContext;
    }

    public bool CnpjIsBeingUsed(string cnpj)
    {
        return _ecommerceContext.Ecommerces.Any(x => x.Cnpj == cnpj);
    }

    public bool EmailIsBeingUsed(string email)
    {
        return _ecommerceContext.Ecommerces.Any(e => e.Email == email);
    }

    public Ecommerce GetByEmail(string email)
    {
        return _ecommerceContext.Ecommerces.FirstOrDefault(x => x.Email == email);
    }

    public int GetTotalApiCredentials(int ecommerceId)
    {
        return _ecommerceContext.ApiCredentials.Where(x => x.Id == ecommerceId).Count();
    }
}
