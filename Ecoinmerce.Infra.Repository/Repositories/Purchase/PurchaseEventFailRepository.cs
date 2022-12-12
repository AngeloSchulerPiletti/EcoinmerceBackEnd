using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Infra.Repository;

public class PurchaseEventFailRepository : GenericRepository<PurchaseEventFail>, IPurchaseEventFailRepository
{
    public PurchaseEventFailRepository(EcommerceContext context) : base(context)
    {

    }
}
