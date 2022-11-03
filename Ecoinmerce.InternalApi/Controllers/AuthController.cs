using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.InternalApi.ControllerAttributes;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.InternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/auth/")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IEcommerceAdminBusiness _ecommerceAdminBusiness;
    private readonly IEcommerceManagerBusiness _ecommerceManagerBusiness;
    private readonly IEcommerceBusiness _ecommerceBusiness;

    public AuthController(IEcommerceAdminBusiness ecommerceAdminBusiness,
                          IEcommerceManagerBusiness ecommerceManagerBusiness,
                          IEcommerceBusiness ecommerceBusiness)
    {
        _ecommerceAdminBusiness = ecommerceAdminBusiness;
        _ecommerceManagerBusiness = ecommerceManagerBusiness;
        _ecommerceBusiness = ecommerceBusiness;
    }

    [Route("register")]
    [HttpPost]
    public IActionResult Register([FromBody] RegisterDTO registerDTO)
    {
        MessageBagVO messageBagManagerValidation = _ecommerceManagerBusiness.Validate(registerDTO.Manager);
        if (messageBagManagerValidation.IsError) return BadRequest(messageBagManagerValidation);

        MessageBagVO messageBagEcommerceValidation = _ecommerceBusiness.Validate(registerDTO.Ecommerce);
        if (messageBagEcommerceValidation.IsError) return BadRequest(messageBagEcommerceValidation);

        MessageBagSingleEntityVO<Ecommerce> messageBagEcommerce = _ecommerceBusiness.Register(registerDTO.Ecommerce);
        if (messageBagEcommerce.IsError) return BadRequest(messageBagEcommerce);

        MessageBagSingleEntityVO<EcommerceManager> messageBagManager = _ecommerceManagerBusiness.Register(registerDTO.Manager, messageBagEcommerce.Entity);
        if (messageBagManager.IsError) return BadRequest(messageBagManager);

        _ecommerceManagerBusiness.SendConfirmationEmailAsync(messageBagManager.Entity);
        _ecommerceBusiness.SendWelcomeEmailAsync(messageBagEcommerce.Entity);

        return Ok(messageBagManager);
    }

    [Route("manager/login")]
    [HttpPost]
    public IActionResult ManagerLogin([FromBody] LoginDTO loginDTO)
    {
        MessageBagSingleEntityVO<EcommerceManager> messageBagManager = _ecommerceManagerBusiness.Login(loginDTO);
        return messageBagManager.IsError ? BadRequest(messageBagManager) : Ok(messageBagManager);
    }

    [HttpGet]
    [ManagerAuth]
    [Route("manager/check-access-token")]
    public IActionResult CheckManagerAccessToken()
    {
        return Ok();
    }

    [HttpPost]
    [Route("manager/refresh-access-token")]
    public IActionResult RefreshManagerAccessToken([FromBody] string refreshToken)
    {
        MessageBagSingleEntityVO<EcommerceManager> messageBagManager = _ecommerceManagerBusiness.RefreshAccessToken(refreshToken);
        return messageBagManager.IsError ? BadRequest(messageBagManager) : Ok(messageBagManager);
    }

    [Route("admin/login")]
    [HttpPost]
    public IActionResult AdminLogin([FromBody] LoginDTO loginDTO)
    {
        MessageBagSingleEntityVO<EcommerceAdmin> messageBagAdmin = _ecommerceAdminBusiness.Login(loginDTO);
        return messageBagAdmin.IsError ? BadRequest(messageBagAdmin) : Ok(messageBagAdmin);
    }

    [HttpGet]
    [AdminAuth]
    [Route("admin/check-access-token")]
    public IActionResult CheckAdminAccessToken()
    {
        return Ok();
    }

    [HttpPost]
    [Route("admin/refresh-access-token")]
    public IActionResult RefreshAdminAccessToken([FromBody] string refreshToken)
    {
        MessageBagSingleEntityVO<EcommerceAdmin> messageBagAdmin = _ecommerceAdminBusiness.RefreshAccessToken(refreshToken);
        return messageBagAdmin.IsError ? BadRequest(messageBagAdmin) : Ok(messageBagAdmin);
    }
}
