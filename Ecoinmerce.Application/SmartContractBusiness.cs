using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Domain.Settings;
using Ecoinmerce.SmartContracts.Interfaces;
using Ecoinmerce.Utils.Json;
using Microsoft.Extensions.Options;

namespace Ecoinmerce.Application;

public class SmartContractBusiness : ISmartContractBusiness
{
    private readonly IOptions<BlockchainSetting> _blockchainSetting;
    private readonly IBinReader _binReader;
    public SmartContractBusiness(IOptions<BlockchainSetting> blockchainSetting, IBinReader binReader)
    {
        _blockchainSetting = blockchainSetting;
        _binReader = binReader;
    }

    public string GetSmartContractAddress()
    {
        return _blockchainSetting.Value.SmartContract.Address;
    }

    public MessageBagSingleEntityVO<string> GetSmartContractJson()
    {
        string smartContractJson = _binReader.GetSmartContractJson();
        if (smartContractJson == null)
            return new("Não foi possível localizar o json do smart contract");

        smartContractJson = JsonFormatter.FormatJsonToInline(smartContractJson);

        return new MessageBagSingleEntityVO<string>("Json encontrado", null, false, smartContractJson);
    }
}
