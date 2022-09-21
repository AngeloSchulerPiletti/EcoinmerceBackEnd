using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.ExternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/shopping/")]
[ApiController]
public class ShoppingController : ControllerBase
{
    // Verify shopping payment (sender: ecommerce | need auth)
    
    // Receive notification of payment intent (sender: ecommerce | need auth | data: purchase ID, amount in R$, purchase date)
}
