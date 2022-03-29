using BarterHash.Domain.Objects.DTO.Ecommerce;
using Microsoft.AspNetCore.Mvc;

namespace BarterHash.InternalApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/auth/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("/signup")]
        public IActionResult SignupUserWithEcommerce([FromBody] NewUserAndEcommerceDTO newUserAndEcommerceDTO)
        {
            // Check if username already exists

            // Check if email was already taken

            // Validate data

            // Send email to confirm user (with authenticated link)

            return Ok();
        }

        [HttpGet]
        [Route("/verify-email/{token}")]
        public IActionResult VerifyEmail([FromQuery] string token)
        {
            // Verify the email in User
            // Return the User data
            return Ok();
        }

        // login

        // delete-account (confirm with email send). the can delete its account (and the eccomerce), but have 1 month until it really delete

        // token validation verifier

        // signup using invite (link)

        // update access token (only the manager can do it)

        // update ecommerce profile (only the manager can do it)
    }
}
