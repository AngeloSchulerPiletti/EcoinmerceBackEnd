using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Objects.DTOs.EcommerceDTO;
using Ecoinmerce.Domain.Objects.VOs.Models;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.ExternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/popup/")]
public class PopUpController : Controller
{
    private readonly IEcommerceBusiness _ecommerceBusiness;
    private readonly ISmartContractBusiness _smartContractBusiness;

    public PopUpController(IEcommerceBusiness ecommerceBusiness, ISmartContractBusiness smartContractBusiness)
    {
        _ecommerceBusiness = ecommerceBusiness;
        _smartContractBusiness = smartContractBusiness;
    }

    [HttpGet]
    [Route("ether/easy-popup")]
    public IActionResult GetEtherEasyPopUp([FromQuery] string purchaseTotal, [FromQuery] string purchaseIdentifier, [FromQuery] int ecommerceId)
    {
        MessageBagSingleEntityVO<string> messageBagSmartContractJson = _smartContractBusiness.GetSmartContractJson();
        if (messageBagSmartContractJson.IsError) return BadRequest(messageBagSmartContractJson);

        MessageBagSingleEntityVO<PublicEcommerce> messageBagEcommerceName = _ecommerceBusiness.GetPublicEcommerceById(ecommerceId);
        if (messageBagEcommerceName.IsError) return BadRequest(messageBagEcommerceName);

        string smartContractAddress = _smartContractBusiness.GetSmartContractAddress();

        PopUpModel model = new()
        {
            SmartContractAddress = smartContractAddress,
            SmartContractJson = messageBagSmartContractJson.Entity,
            EcommerceName = messageBagEcommerceName.Entity.FantasyName,
            EcommerceAddress = messageBagEcommerceName.Entity.WalletAddress,
            PurchaseIdentifier = purchaseIdentifier,
            PurchaseTotal = purchaseTotal
        };

        return View("~/PopUp/Ether/Index.cshtml", model);
    }
}
