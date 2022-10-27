
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Infra.ViaCep.Interfaces;

public interface IViaCepService
{
    public ViaCepResponseVO GetCompleteAddress(string cep);
}
