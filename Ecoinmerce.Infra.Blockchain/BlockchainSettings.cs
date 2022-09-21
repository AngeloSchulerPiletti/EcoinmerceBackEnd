
namespace Ecoinmerce.Infra.Blockchain;

public class BlockchainSettings
{
    public BlockchainSettingsBlockchain Blockchain { get; set; }
    public BlockchainSettingsAccount Account { get; set; }
    public BlockchainSettingsSmartContract SmartContract { get; set; }

}

public class BlockchainSettingsBlockchain
{
    public string WsUrl { get; set; }
    public string HttpUrl { get; set; }
    public string Port { get; set; }
}

public class BlockchainSettingsAccount
{
    public string Address { get; set; }
    public string PrivateKey { get; set; }
}

public class BlockchainSettingsSmartContract
{
    public string Address { get; set; }

}