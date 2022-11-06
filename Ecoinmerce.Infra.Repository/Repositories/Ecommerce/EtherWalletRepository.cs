using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository;

public class EtherWalletRepository : GenericRepository<EtherWallet>, IEtherWalletRepository
{
    private readonly EcommerceContext _ecommerceContext;

    public EtherWalletRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
    {
        _ecommerceContext = ecommerceContext;
    }

    public int GetLastEtherWalletId()
    {
        //return _ecommerceContext.EtherWallets.OrderBy(x => x.Id).Select(x => x.Id).Last(); // Descomenta isso
        return 1; //Apaga isso{{ _.internalApiBaseUrl }}/api/v1/smart-contract/address
    }
}
