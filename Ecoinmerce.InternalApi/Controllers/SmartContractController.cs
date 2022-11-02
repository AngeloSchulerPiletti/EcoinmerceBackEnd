using Ecoinmerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.InternalApi.Controllers;


[ApiVersion("1")]
[Route("api/v{version:apiVersion}/smart-contract/")]
[ApiController]
public class SmartContractController : ControllerBase
{
    private readonly ISmartContractBusiness _smartContractBusiness;
    public SmartContractController(ISmartContractBusiness smartContractBusiness)
    {
        _smartContractBusiness = smartContractBusiness;
    }

    [HttpGet]
    [Route("address")]
    public IActionResult GetAddress()
    {
        return Ok(_smartContractBusiness.GetSmartContractAddress());
    }
}
