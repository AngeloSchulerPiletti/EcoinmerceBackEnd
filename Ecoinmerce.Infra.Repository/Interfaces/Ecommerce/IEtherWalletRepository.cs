using Ecoinmerce.Domain.Entities;

namespace Ecoinmerce.Infra.Repository.Interfaces;

public interface IEtherWalletRepository : IGenericRepository<EtherWallet>
{
    public int GetLastEtherWalletId();
}
