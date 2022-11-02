using Castle.Core.Resource;
using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.InternalApi.ControllerAttributes;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.InternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/api-credential/")]
[ApiController]
public class ApiCredentialController : ControllerBase
{
    private readonly IApiCredentialBusiness _apiCredentialBusiness;

    public ApiCredentialController(IApiCredentialBusiness apiCredentialBusiness)
    {
        _apiCredentialBusiness = apiCredentialBusiness;
    }

    [AdminOrManagerAuth]
    [HttpGet]
    [Route("max-credentials")]
    public IActionResult GetMaxCredentials()
    {
        return Ok(_apiCredentialBusiness.GetMaxCredentials());
    }

    [ManagerAuth]
    [HttpPost]
    [Route("create-credential")]
    public IActionResult CreateCredential([FromBody] ApiCredential apiCredential)
    {
        EcommerceManager manager = (EcommerceManager)HttpContext.Items["Manager"];
        Ecommerce ecommerce = manager.Ecommerce;

        MessageBagVO messageBagMaxCredentialsValidate = _apiCredentialBusiness.ValidateMaxCredentials(ecommerce);
        if (messageBagMaxCredentialsValidate.IsError) return BadRequest(messageBagMaxCredentialsValidate);

        MessageBagVO messageBagValidation = _apiCredentialBusiness.ValidateNewApiCredential(apiCredential);
        if(messageBagValidation.IsError) return BadRequest(messageBagValidation);

        MessageBagSingleEntityVO<ApiCredential> messageBagApiCredential = _apiCredentialBusiness.CreateApiCredential(ecommerce, apiCredential);
        return messageBagApiCredential.IsError ? BadRequest(messageBagApiCredential) : Ok(messageBagApiCredential);
    }

}
