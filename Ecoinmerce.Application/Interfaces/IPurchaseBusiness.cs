using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs.Requests;
using Ecoinmerce.Domain.Objects.VOs.Filters;
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Interfaces;

public interface IPurchaseBusiness
{
    public MessageBagSingleEntityVO<Purchase> GetEcommercePurchaseById(int purchaseId, Ecommerce ecommerce);
    public MessageBagSingleEntityVO<Purchase> GetPurchaseById(int id);
    public MessageBagListEntityVO<Purchase> GetPurchasesByFilter(PurchaseFilter filter, PaginationDTO pagination);
    public MessageBagSingleEntityVO<Purchase> UpdatePurchaseObservation(Purchase purchase, string observation);
}
