using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.InternalApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/shopping-data/")]
    [ApiController]
    public class ShoppingDataController : ControllerBase
    {
        // get specific user data
    }
}
