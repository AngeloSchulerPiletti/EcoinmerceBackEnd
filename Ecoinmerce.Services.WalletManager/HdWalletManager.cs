using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Services.WalletManager.Interfaces;
using Nethereum.HdWallet;
using Nethereum.JsonRpc.Client;
using Nethereum.Web3.Accounts;

namespace Ecoinmerce.Services.WalletManager;

public class HdWalletManager : IHdWalletManager
{
    private readonly HdWalletCredentialSetting _hdWalletCredentialSetting;

    public HdWalletManager(HdWalletCredentialSetting hdWalletCredentialSetting)
    {
        _hdWalletCredentialSetting = hdWalletCredentialSetting;
    }

    public Account GetWalletAccount(int id)
    {
        Wallet wallet = new(_hdWalletCredentialSetting.SeedWords, _hdWalletCredentialSetting.Password);
        return wallet.GetAccount(id);
    }
}
