using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Infra.Repository.Repositories;

public class PurchaseEventRepository : GenericRepository<PurchaseEvent>, IPurchaseEventRepository
{
    public PurchaseEventRepository(PurchaseContext context) : base(context)
    {

    }
}
