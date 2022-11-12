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

    [Route("ecommerce/confirm-email")]
    [HttpPost]
    public IActionResult EcommerceConfirmEmail([FromBody] string confirmationToken)
    {
        MessageBagVO messageBagConfirmation = _ecommerceBusiness.ConfirmEmail(confirmationToken);
        return messageBagConfirmation.IsError ? BadRequest(messageBagConfirmation) : Ok(messageBagConfirmation);
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

    [Route("manager/confirm-email")]
    [HttpPost]
    public IActionResult ManagerConfirmEmail([FromBody] string confirmationToken)
    {
        MessageBagVO messageBagConfirmation = _ecommerceManagerBusiness.ConfirmEmail(confirmationToken);
        return messageBagConfirmation.IsError ? BadRequest(messageBagConfirmation) : Ok(messageBagConfirmation);
    }

    [Route("manager/resend-email-confirmation")]
    [HttpPost]
    public IActionResult ManagerResendConfirmEmail([FromBody] string email)
    {
        MessageBagSingleEntityVO<EcommerceManager> messageBagManager = _ecommerceManagerBusiness.GetManagerByEmail(email);
        if(messageBagManager.IsError) return BadRequest(messageBagManager);

        MessageBagVO messageBagValidate = _ecommerceManagerBusiness.ValidateForResendConfirmationEmail(messageBagManager.Entity);
        if(messageBagValidate.IsError) return BadRequest(messageBagValidate);

        MessageBagVO messageBagSetup = _ecommerceManagerBusiness.SetupForEmailConfirmation(messageBagManager.Entity, true);
        if(messageBagSetup.IsError) return BadRequest(messageBagSetup);

        _ecommerceManagerBusiness.SendConfirmationEmailAsync(messageBagManager.Entity);

        return Ok(messageBagSetup);
    }

    [Route("manager/forgot-password")]
    [HttpPost]
    public IActionResult ManagerForgotPassword([FromBody] string email)
    {
        MessageBagSingleEntityVO<EcommerceManager> messageBagManager = _ecommerceManagerBusiness.GetManagerByEmail(email);
        if (messageBagManager.IsError) return BadRequest(messageBagManager);

        MessageBagVO messageBagValidate = _ecommerceManagerBusiness.ValidateForChangePassword(messageBagManager.Entity);
        if (messageBagValidate.IsError) return BadRequest(messageBagValidate);

        _ecommerceManagerBusiness.SendForgotPasswordEmailAsync(messageBagManager.Entity);

        return Ok(messageBagValidate);
    }

    [Route("manager/forgot-password/change/{token}")]
    [HttpPost]
    public IActionResult ManagerForgotPasswordChange([FromBody] string nakedPassword, string token)
    {
        MessageBagVO messageBagValidate = _ecommerceManagerBusiness.ValidateConfirmationToken(token);
        if(messageBagValidate.IsError) return BadRequest(messageBagValidate);

        MessageBagSingleEntityVO<EcommerceManager> messageBagManager = _ecommerceManagerBusiness.GetManagerByConfirmationToken(token);
        if (messageBagManager.IsError) return BadRequest(messageBagManager);

        MessageBagSingleEntityVO<EcommerceManager> messageBagPasswordChange = _ecommerceManagerBusiness.ChangePassword(messageBagManager.Entity, nakedPassword);
        return messageBagPasswordChange.IsError ? BadRequest(messageBagPasswordChange) : Ok(messageBagPasswordChange);
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

    [Route("admin/confirm-email")]
    [HttpPost]
    public IActionResult AdminConfirmEmail([FromBody] string confirmationToken)
    {
        MessageBagVO messageBagConfirmation = _ecommerceAdminBusiness.ConfirmEmail(confirmationToken);
        return messageBagConfirmation.IsError ? BadRequest(messageBagConfirmation) : Ok(messageBagConfirmation);
    }

    [Route("admin/resend-email-confirmation")]
    [HttpPost]
    public IActionResult AdminResendConfirmEmail([FromBody] string email)
    {
        MessageBagSingleEntityVO<EcommerceAdmin> messageBagAdmin = _ecommerceAdminBusiness.GetAdminByEmail(email);
        if (messageBagAdmin.IsError) return BadRequest(messageBagAdmin);

        MessageBagVO messageBagValidate = _ecommerceAdminBusiness.ValidateForResendConfirmationEmail(messageBagAdmin.Entity);
        if (messageBagValidate.IsError) return BadRequest(messageBagValidate);

        MessageBagVO messageBagSetup = _ecommerceAdminBusiness.SetupForEmailConfirmation(messageBagAdmin.Entity, true);
        if (messageBagSetup.IsError) return BadRequest(messageBagSetup);

        _ecommerceAdminBusiness.SendConfirmationEmailAsync(messageBagAdmin.Entity);

        return Ok(messageBagSetup);
    }

    [Route("admin/forgot-password")]
    [HttpPost]
    public IActionResult AdminForgotPassword([FromBody] string email)
    {
        MessageBagSingleEntityVO<EcommerceAdmin> messageBagAdmin = _ecommerceAdminBusiness.GetAdminByEmail(email);
        if (messageBagAdmin.IsError) return BadRequest(messageBagAdmin);

        MessageBagVO messageBagValidate = _ecommerceAdminBusiness.ValidateForChangePassword(messageBagAdmin.Entity);
        if (messageBagValidate.IsError) return BadRequest(messageBagValidate);

        _ecommerceAdminBusiness.SendForgotPasswordEmailAsync(messageBagAdmin.Entity);

        return Ok(messageBagValidate);
    }

    [Route("admin/forgot-password/change/{token}")]
    [HttpPost]
    public IActionResult AdminForgotPasswordChange([FromBody] string nakedPassword, string token)
    {
        MessageBagVO messageBagValidate = _ecommerceAdminBusiness.ValidateConfirmationToken(token);
        if (messageBagValidate.IsError) return BadRequest(messageBagValidate);

        MessageBagSingleEntityVO<EcommerceAdmin> messageBagAdmin = _ecommerceAdminBusiness.GetAdminByConfirmationToken(token);
        if (messageBagAdmin.IsError) return BadRequest(messageBagAdmin);

        MessageBagSingleEntityVO<EcommerceAdmin> messageBagPasswordChange = _ecommerceAdminBusiness.ChangePassword(messageBagAdmin.Entity, nakedPassword);
        return messageBagPasswordChange.IsError ? BadRequest(messageBagPasswordChange) : Ok(messageBagPasswordChange);
    }
}
