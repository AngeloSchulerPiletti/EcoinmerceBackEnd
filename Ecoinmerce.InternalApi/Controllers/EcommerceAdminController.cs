using Ecoinmerce.Application.Interfaces;
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
}
