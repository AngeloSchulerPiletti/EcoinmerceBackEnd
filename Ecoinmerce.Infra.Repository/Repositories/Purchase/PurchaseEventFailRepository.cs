using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Infra.Repository.Repositories;

public class PurchaseEventFailRepository : GenericRepository<PurchaseEventFail>, IPurchaseEventFailRepository
{
    public PurchaseEventFailRepository(PurchaseContext context) : base(context)
    {

    }
}
