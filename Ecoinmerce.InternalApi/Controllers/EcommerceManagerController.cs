using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.InternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/manager/")]
[ApiController]
public class EcommerceManagerController : ControllerBase
{
    private readonly IEcommerceManagerBusiness _ecommerceManagerBusiness;

    public EcommerceManagerController(IEcommerceManagerBusiness ecommerceManagerBusiness)
    {
        _ecommerceManagerBusiness = ecommerceManagerBusiness;
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromBody] LoginDTO loginDTO)
    {
        MessageBagSingleEntityVO<EcommerceManager> messageBagManager = _ecommerceManagerBusiness.Login(loginDTO);
        return messageBagManager.IsError ? BadRequest(messageBagManager) : Ok(messageBagManager);
    }
}
