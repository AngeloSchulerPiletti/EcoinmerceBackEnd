using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Infra.Blockchain;
using Microsoft.Extensions.Options;

namespace Ecoinmerce.Application;

public class SmartContractBusiness : ISmartContractBusiness
{
    private readonly IOptions<BlockchainSettings> _blockchainSettings;
    public SmartContractBusiness(IOptions<BlockchainSettings> blockchainSettings)
    {
        _blockchainSettings = blockchainSettings;
    }

    public string GetSmartContractAddress()
    {
        return _blockchainSettings.Value.SmartContract.Address;
    }
}
