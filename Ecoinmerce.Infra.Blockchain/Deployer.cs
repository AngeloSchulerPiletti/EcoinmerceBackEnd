using Ecoinmerce.Domain.Settings;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace Ecoinmerce.Infra.Blockchain;

public class Deployer
{
    private readonly Account _account;
    private readonly Web3 _web3;

    public Deployer(BlockchainSetting blockchainSetting)
    {
        string httpUrl = $"{blockchainSetting.Blockchain.HttpUrl}:{blockchainSetting.Blockchain.Port}";
        _account = new(blockchainSetting.Account.PrivateKey);
        _web3 = new(_account, httpUrl);
    }

    public async Task<TransactionReceipt> DeploySmartContract<ContractDefinition>(ContractDefinition contractModel) where ContractDefinition : ContractDeploymentMessage, new()
    {
        var deploymentHandler = _web3.Eth.GetContractDeploymentHandler<ContractDefinition>();

        _web3.TransactionManager.UseLegacyAsDefault = true;
        return await deploymentHandler.SendRequestAndWaitForReceiptAsync(contractModel);
    }
}
