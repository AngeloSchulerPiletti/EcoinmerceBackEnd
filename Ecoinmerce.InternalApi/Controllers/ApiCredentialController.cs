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
        if (messageBagValidation.IsError) return BadRequest(messageBagValidation);

        MessageBagSingleEntityVO<ApiCredential> messageBagApiCredential = _apiCredentialBusiness.CreateApiCredential(ecommerce, apiCredential);
        return messageBagApiCredential.IsError ? BadRequest(messageBagApiCredential) : Ok(messageBagApiCredential);
    }

    [AdminOrManagerAuth]
    [HttpGet]
    [Route("list")]
    public IActionResult GetCredentials()
    {
        Ecommerce ecommerce;

        EcommerceManager manager = (EcommerceManager)HttpContext.Items["Manager"];
        EcommerceAdmin admin = (EcommerceAdmin)HttpContext.Items["Admin"];

        ecommerce = manager == null ? admin.Ecommerce : manager.Ecommerce;

        MessageBagListEntityVO<ApiCredential> messageBagCredentials = _apiCredentialBusiness.GetApiCredentialsByEcommerceId(ecommerce.Id);
        return messageBagCredentials.IsError ? BadRequest(messageBagCredentials) : Ok(messageBagCredentials);
    }

    [AdminOrManagerAuth]
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetCredential(int id)
    {
        Ecommerce ecommerce;

        EcommerceManager manager = (EcommerceManager)HttpContext.Items["Manager"];
        EcommerceAdmin admin = (EcommerceAdmin)HttpContext.Items["Admin"];

        ecommerce = manager == null ? admin.Ecommerce : manager.Ecommerce;

        MessageBagSingleEntityVO<ApiCredential> messageBagCredential = _apiCredentialBusiness.GetEcommerceApiCredentialById(ecommerce, id);
        return messageBagCredential.IsError ? BadRequest(messageBagCredential) : Ok(messageBagCredential);
    }

    [ManagerAuth]
    [HttpDelete]
    [Route("delete-credential/{id}")]
    public IActionResult DeleteCredential(int id)
    {
        EcommerceManager manager = (EcommerceManager)HttpContext.Items["Manager"];
        Ecommerce ecommerce = manager.Ecommerce;

        MessageBagSingleEntityVO<ApiCredential> messageBagApiCredential = _apiCredentialBusiness.GetEcommerceApiCredentialById(ecommerce, id);
        if (messageBagApiCredential.IsError) return BadRequest(messageBagApiCredential);

        MessageBagVO messageBagDelete = _apiCredentialBusiness.DeleteApiCredential(messageBagApiCredential.Entity);
        return messageBagDelete.IsError ? BadRequest(messageBagDelete) : Ok(messageBagDelete);
    }


    [ManagerAuth]
    [HttpPut]
    [Route("update-credential")]
    public IActionResult UpdateCredential([FromBody] ApiCredential apiCredentialUpdate)
    {
        EcommerceManager manager = (EcommerceManager)HttpContext.Items["Manager"];
        Ecommerce ecommerce = manager.Ecommerce;

        MessageBagVO messageBagValidation = _apiCredentialBusiness.ValidateUpdateApiCredential(apiCredentialUpdate);
        if (messageBagValidation.IsError) return BadRequest(messageBagValidation);

        MessageBagSingleEntityVO<ApiCredential> messageBagApiCredential = _apiCredentialBusiness.GetEcommerceApiCredentialById(ecommerce, apiCredentialUpdate.Id);
        if (messageBagApiCredential.IsError) return BadRequest(messageBagApiCredential);

        MessageBagSingleEntityVO<ApiCredential> messageBagUpdatedApiCredential = _apiCredentialBusiness.UpdateApiCredential(messageBagApiCredential.Entity, apiCredentialUpdate);
        return messageBagUpdatedApiCredential.IsError ? BadRequest(messageBagUpdatedApiCredential) : Ok(messageBagUpdatedApiCredential);
    }

    [ManagerAuth]
    [HttpPost]
    [Route("renew-credential/{id}")]
    public IActionResult RenewCredential(int id)
    {
        EcommerceManager manager = (EcommerceManager)HttpContext.Items["Manager"];
        Ecommerce ecommerce = manager.Ecommerce;

        MessageBagSingleEntityVO<ApiCredential> messageBagApiCredential = _apiCredentialBusiness.GetEcommerceApiCredentialById(ecommerce, id);
        if (messageBagApiCredential.IsError) return BadRequest(messageBagApiCredential);

        MessageBagSingleEntityVO<ApiCredential> messageBagApiCredentialRenew = _apiCredentialBusiness.RenewCredential(ecommerce, messageBagApiCredential.Entity);
        return messageBagApiCredentialRenew.IsError ? BadRequest(messageBagApiCredentialRenew) : Ok(messageBagApiCredentialRenew);
    }
}
