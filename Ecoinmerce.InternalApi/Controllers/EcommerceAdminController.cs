using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.InternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/admin/")]
[ApiController]
public class EcommerceAdminController : ControllerBase
{
    private readonly IEcommerceAdminBusiness _ecommerceAdminBusiness;

    public EcommerceAdminController(IEcommerceAdminBusiness ecommerceAdminBusiness)
    {
        _ecommerceAdminBusiness = ecommerceAdminBusiness;
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromBody] LoginDTO loginDTO)
    {
        MessageBagSingleEntityVO<EcommerceAdmin> messageBagAdmin = _ecommerceAdminBusiness.Login(loginDTO);
        return messageBagAdmin.IsError ? BadRequest(messageBagAdmin) : Ok(messageBagAdmin);
    }
}
