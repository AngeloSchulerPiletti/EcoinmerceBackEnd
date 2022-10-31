using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Application;

public class ApiCredentialBusiness : IApiCredentialBusiness
{
    private readonly IApiCredentialRepository _apiCredentialRepository;
}
