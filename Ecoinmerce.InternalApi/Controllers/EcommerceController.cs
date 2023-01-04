using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.InternalApi.ControllerAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.InternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/ecommerce/")]
[ApiController]
public class EcommerceController : ControllerBase
{
    private readonly IEcommerceBusiness _ecommerceBusiness;

    public EcommerceController(IEcommerceBusiness ecommerceBusiness)
    {
        _ecommerceBusiness = ecommerceBusiness;
    }

    [HttpGet]
    [AdminOrManagerAuth]
    public IActionResult GetEcommerce()
    {
        EcommerceManager manager = (EcommerceManager)HttpContext.Items["Manager"];
        EcommerceAdmin admin = (EcommerceAdmin)HttpContext.Items["Admin"];

        Ecommerce ecommerce = manager == null ? admin.Ecommerce : manager.Ecommerce;
        return Ok(ecommerce);
    }
}
