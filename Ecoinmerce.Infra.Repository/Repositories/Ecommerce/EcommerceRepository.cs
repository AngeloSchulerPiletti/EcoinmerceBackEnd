using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository.Interfaces;

public class EcommerceRepository : GenericRepository<Ecommerce>, IEcommerceRepository
{
    public EcommerceRepository(DbContext context) : base(context)
    {
    }
}
