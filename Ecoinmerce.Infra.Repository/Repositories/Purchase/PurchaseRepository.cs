using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs.Requests;
using Ecoinmerce.Domain.Objects.VOs.Filters;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository;

public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
{
    private readonly EcommerceContext _ecommerceContext;
    public PurchaseRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
    {
        _ecommerceContext = ecommerceContext;
    }

    public List<Purchase> GetPurchasesByFilter(ref PaginationDTO pagination, PurchaseFilter filter, Ecommerce ecommerce)
    {
        string queryId = filter.GetQueryId();
        int total = _ecommerceContext.Purchases.FromSqlRaw(queryId).Where(x => x.EcommerceId == ecommerce.Id).Count();
        pagination.FillBasedInTotalItems(total);

        if (total == 0) return new List<Purchase>();

        string query = filter.GetQuery();
        return _ecommerceContext.Purchases
                                .FromSqlRaw(query)
                                .Where(x => x.EcommerceId == ecommerce.Id)
                                .Skip(pagination.Skip)
                                .Take(pagination.Limit)
                                .ToList();
    }
}
