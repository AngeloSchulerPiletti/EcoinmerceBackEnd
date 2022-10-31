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
}
