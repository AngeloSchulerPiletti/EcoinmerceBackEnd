using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.ExternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/midia/")]
[ApiController]
public class MidiaController : ControllerBase
{
    [HttpGet]
    [Route("brand")]
    public IActionResult GetMidia()
    {

    }
}
