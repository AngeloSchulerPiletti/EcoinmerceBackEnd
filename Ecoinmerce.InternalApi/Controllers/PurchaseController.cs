using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs.Filters;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.InternalApi.ControllerAttributes;
using EcoinmerceInfra.Api.Management.ControllerAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.InternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/purchase/")]
[ApiController]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseBusiness _purchaseBusiness;

    public PurchaseController(IPurchaseBusiness purchaseBusiness)
    {
        _purchaseBusiness = purchaseBusiness;
    }

    [HttpGet]
    [Route("list")]
    [AdminOrManagerAuth]
    [Pagination]
    public IActionResult GetPurchases([FromBody] PurchaseFilter filter)
    {
        Ecommerce ecommerce;

        EcommerceManager manager = (EcommerceManager)HttpContext.Items["Manager"];
        EcommerceAdmin admin = (EcommerceAdmin)HttpContext.Items["Admin"];

        ecommerce = manager == null ? admin.Ecommerce : manager.Ecommerce;

        return BadRequest("Pede pro angelo terminar");

    }

    [HttpGet]
    [Route("{id}")]
    [AdminOrManagerAuth]
    public IActionResult GetPurchase(int id)
    {
        Ecommerce ecommerce;

        EcommerceManager manager = (EcommerceManager)HttpContext.Items["Manager"];
        EcommerceAdmin admin = (EcommerceAdmin)HttpContext.Items["Admin"];

        ecommerce = manager == null ? admin.Ecommerce : manager.Ecommerce;

        MessageBagSingleEntityVO<Purchase> messageBagPurchase = _purchaseBusiness.GetEcommercePurchaseById(id, ecommerce);
        return messageBagPurchase.IsError ? BadRequest(messageBagPurchase) : Ok(messageBagPurchase);
    }

    [HttpPut]
    [Route("{id}")]
    [AdminOrManagerAuth]
    public IActionResult PutPurchaseObservation([FromBody] string observation, int id)
    {
        Ecommerce ecommerce;

        EcommerceManager manager = (EcommerceManager)HttpContext.Items["Manager"];
        EcommerceAdmin admin = (EcommerceAdmin)HttpContext.Items["Admin"];

        ecommerce = manager == null ? admin.Ecommerce : manager.Ecommerce;

        MessageBagSingleEntityVO<Purchase> messageBagPurchase = _purchaseBusiness.GetEcommercePurchaseById(id, ecommerce);
        if (messageBagPurchase.IsError) BadRequest(messageBagPurchase);

        MessageBagSingleEntityVO<Purchase> messageBagUpdate = _purchaseBusiness.UpdatePurchaseObservation(messageBagPurchase.Entity, observation);
        return messageBagUpdate.IsError ? BadRequest(messageBagUpdate) : Ok(messageBagUpdate);
    }

}
