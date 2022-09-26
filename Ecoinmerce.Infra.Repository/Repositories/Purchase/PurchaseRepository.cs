using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Infra.Repository.Repositories;

public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(PurchaseContext context) : base(context)
    {

    }
}
