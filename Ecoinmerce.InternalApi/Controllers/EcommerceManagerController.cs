using Ecoinmerce.Application.Interfaces;
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
}
