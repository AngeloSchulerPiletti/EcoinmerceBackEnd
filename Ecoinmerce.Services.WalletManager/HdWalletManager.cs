using Ecoinmerce.Services.WalletManager.Interfaces;
using Nethereum.HdWallet;
using Nethereum.JsonRpc.Client;
using Nethereum.Web3.Accounts;

namespace Ecoinmerce.Services.WalletManager;

public class HdWalletManager : IHdWalletManager
{
    private readonly HdWalletCredentials _walletCredentials;

    public HdWalletManager(HdWalletCredentials walletCredentials)
    {
        _walletCredentials = walletCredentials;
    }

    public Account GetWalletAccount(int id)
    {
        Wallet wallet = new(_walletCredentials.SeedWords, _walletCredentials.Password);
        return wallet.GetAccount(id);
    }
}
