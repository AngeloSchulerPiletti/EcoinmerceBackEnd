using Ecoinmerce.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.ExternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/api-credential/")]
[ApiController]
public class ApiCredentialController : ControllerBase
{
    private readonly IApiCredentialBusiness _apiCredentialBusiness;

    public ApiCredentialController(IApiCredentialBusiness apiCredentialBusiness)
    {
        _apiCredentialBusiness = apiCredentialBusiness;
    }
}