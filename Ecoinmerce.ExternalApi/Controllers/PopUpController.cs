using Ecoinmerce.Application.Interfaces;
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

        MessageBagSingleEntityVO<string> messageBagEcommerceName = _ecommerceBusiness.GetEcommerceNameById(ecommerceId);
        if (messageBagEcommerceName.IsError) return BadRequest(messageBagEcommerceName);

        ViewBag.smartContractJson = messageBagSmartContractJson.Entity;
        ViewBag.ecommerceName = messageBagEcommerceName.Entity;
        ViewBag.purchaseTotal = purchaseTotal;
        return View("~/PopUp/Ether/Index.cshtml");
    }
}
