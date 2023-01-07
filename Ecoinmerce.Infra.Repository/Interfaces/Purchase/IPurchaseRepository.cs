using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs.Requests;
using Ecoinmerce.Domain.Objects.VOs.Filters;

namespace Ecoinmerce.Infra.Repository.Interfaces;

public interface IPurchaseRepository : IGenericRepository<Purchase>
{
    public List<Purchase> GetPurchasesByFilter(ref PaginationDTO pagination, PurchaseFilter filter);
}
