using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Infra.Repository.Repositories;

public class PurchaseCheckRepository : GenericRepository<PurchaseCheck>, IPurchaseCheckRepository
{
    public PurchaseCheckRepository(PurchaseContext context) : base(context)
    {

    }
}
