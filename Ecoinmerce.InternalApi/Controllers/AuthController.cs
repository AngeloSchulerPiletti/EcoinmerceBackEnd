using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.InternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/auth/")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IEcommerceAdminBusiness _ecommerceAdminBusiness;
    private readonly IEcommerceManagerBusiness _ecommerceManagerBusiness;

    public AuthController(IEcommerceAdminBusiness ecommerceAdminBusiness, IEcommerceManagerBusiness ecommerceManagerBusiness)
    {
        _ecommerceAdminBusiness = ecommerceAdminBusiness;
        _ecommerceManagerBusiness = ecommerceManagerBusiness;
    }

    [Route("manager/login")]
    [HttpPost]
    public IActionResult ManagerLogin([FromBody] LoginDTO loginDTO)
    {
        MessageBagSingleEntityVO<EcommerceManager> messageBagManager = _ecommerceManagerBusiness.Login(loginDTO);
        return messageBagManager.IsError ? BadRequest(messageBagManager) : Ok(messageBagManager);
    }

    [Route("admin/login")]
    [HttpPost]
    public IActionResult AdminLogin([FromBody] LoginDTO loginDTO)
    {
        MessageBagSingleEntityVO<EcommerceAdmin> messageBagAdmin = _ecommerceAdminBusiness.Login(loginDTO);
        return messageBagAdmin.IsError ? BadRequest(messageBagAdmin) : Ok(messageBagAdmin);
    }

    [Route("register")]
    [HttpPost]
    public IActionResult Register([FromBody] RegisterDTO registerDTO)
    {

    }
}
