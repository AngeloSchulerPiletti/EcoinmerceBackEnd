using Microsoft.AspNetCore.Mvc;

namespace BarterHash.InternalApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/auth/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // signup (confirm with email send) with ecommerce creation!

        // login

        // delete-account (confirm with email send). the can delete its account (and the eccomerce), but have 1 month until it really delete

        // token validation verifier

        // signup using invite

        // update access token (only the manager can do it)

        // update ecommerce profile (only the manager can do it)
    }
}
