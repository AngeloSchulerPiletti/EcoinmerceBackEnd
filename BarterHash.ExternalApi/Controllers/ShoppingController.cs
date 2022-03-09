using BarterHash.Domain.ContractInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nethereum.Contracts;
using Nethereum.JsonRpc.WebSocketStreamingClient;
using Nethereum.RPC.Reactive.Eth.Subscriptions;

namespace BarterHash.ExternalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {

        // Verify shopping payment (sender: ecommerce | need auth)
        
        // Receive notification of payment intent (sender: ecommerce | need auth | data: purchase ID, amount in R$, purchase date)
    }
}
