using Nethereum.Web3.Accounts;

namespace Ecoinmerce.Services.WalletManager.Interfaces;

public interface IHdWalletManager
{
    public Account GetWalletAccount(int id);
}
