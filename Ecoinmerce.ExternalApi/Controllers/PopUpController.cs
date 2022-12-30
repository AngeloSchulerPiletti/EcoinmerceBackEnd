using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.ExternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/popup/")]
public class PopUpController : Controller
{
    [HttpGet]
    [Route("ether/easy-popup")]
    public IActionResult GetEtherEasyPopUp([FromQuery] string purchaseTotal, [FromQuery] string purchaseIdentifier, [FromQuery] uint ecommerceId)
    {

        return View("~/PopUp/Ether/Index.cshtml");
    }
}
