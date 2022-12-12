using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Infra.Repository;

public class PurchaseEventRepository : GenericRepository<PurchaseEvent>, IPurchaseEventRepository
{
    public PurchaseEventRepository(EcommerceContext context) : base(context)
    {

    }
}
