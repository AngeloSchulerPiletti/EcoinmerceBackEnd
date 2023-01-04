using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Interfaces;

public interface ISmartContractBusiness
{
    public string GetSmartContractAddress();
    public MessageBagSingleEntityVO<string> GetSmartContractJson();
}
