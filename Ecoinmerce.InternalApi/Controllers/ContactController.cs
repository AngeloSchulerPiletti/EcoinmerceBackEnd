using Ecoinmerce.Domain.Objects.VOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.InternalApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/contact/")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpPost]
        [Route("from-home")]
        public IActionResult FromHome([FromBody] EmailMessageVO emailMessage)
        {
            return Ok("Mensagem não enviada porque o Angelo ainda não implementou, mas o endpoint existe");
        }
    }
}
