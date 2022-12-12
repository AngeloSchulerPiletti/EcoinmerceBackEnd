using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs.Requests;
using Ecoinmerce.Domain.Objects.VOs.Filters;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Infra.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecoinmerce.Application;

public class PurchaseBusiness : IPurchaseBusiness
{
    private readonly IPurchaseRepository _purchaseRepository;

    public PurchaseBusiness(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public MessageBagSingleEntityVO<Purchase> GetEcommercePurchaseById(int purchaseId, Ecommerce ecommerce)
    {
        Purchase purchase = ecommerce.Purchases.FirstOrDefault(x => x.Id == purchaseId);
        return purchase == null ?
               new MessageBagSingleEntityVO<Purchase>("Essa transação não foi realizada", "Transação não encontrada") :
               new MessageBagSingleEntityVO<Purchase>("Transação encontrada", null, false, purchase);
    }

    public MessageBagSingleEntityVO<Purchase> GetPurchaseById(int id)
    {
        Purchase purchase = _purchaseRepository.GetById(id);
        return purchase == null ?
               new MessageBagSingleEntityVO<Purchase>("Essa transação não foi realizada", "Transação não encontrada") :
               new MessageBagSingleEntityVO<Purchase>("Transação encontrada", null, false, purchase);
    }

    public MessageBagListEntityVO<Purchase> GetPurchasesByFilter(PurchaseFilter filter, PaginationDTO pagination)
    {
        throw new NotImplementedException();
    }

    public MessageBagSingleEntityVO<Purchase> UpdatePurchaseObservation(Purchase purchase, string observation)
    {
        if (observation != null && observation.Length > 300)
            return new MessageBagSingleEntityVO<Purchase>("A observação não pode ultrapassar 300 caracteres", "Erro de solicitação");

        purchase.Observation = observation;
        bool saveResult = _purchaseRepository.SaveChanges();
        return saveResult ?
            new MessageBagSingleEntityVO<Purchase>("Alterações salvas com sucesso", "Sucesso", false, purchase) :
            new MessageBagSingleEntityVO<Purchase>("Tivemos um problema ao salvar as alterações", "Erro nosso...");
    }
}
