using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Settings;
using Microsoft.Extensions.Options;

namespace Ecoinmerce.Application;

public class SmartContractBusiness : ISmartContractBusiness
{
    private readonly IOptions<BlockchainSetting> _blockchainSetting;
    public SmartContractBusiness(IOptions<BlockchainSetting> blockchainSetting)
    {
        _blockchainSetting = blockchainSetting;
    }

    public string GetSmartContractAddress()
    {
        return _blockchainSetting.Value.SmartContract.Address;
    }
}
