using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Microsoft.AspNetCore.Mvc;

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


    [HttpGet]
    [Route("bin/json")]
    public IActionResult GetSmartContractJson()
    {
        MessageBagSingleEntityVO<string> messageBagJson = _smartContractBusiness.GetSmartContractJson();
        return messageBagJson.IsError ? BadRequest(messageBagJson) : Ok(messageBagJson);
    }

}
