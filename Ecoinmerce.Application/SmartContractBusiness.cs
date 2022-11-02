using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Infra.Blockchain;

namespace Ecoinmerce.Application;

public class SmartContractBusiness : ISmartContractBusiness
{
    private readonly BlockchainSettings _blockchainSettings;
    public SmartContractBusiness(BlockchainSettings blockchainSettings)
    {
        _blockchainSettings = blockchainSettings;
    }

    public string GetSmartContractAddress()
    {
        return _blockchainSettings.SmartContract.Address;
    }
}
