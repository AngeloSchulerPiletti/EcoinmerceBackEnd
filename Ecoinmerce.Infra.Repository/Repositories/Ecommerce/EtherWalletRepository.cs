using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository.Repositories;

public class EtherWalletRepository : GenericRepository<EtherWallet>, IEtherWalletRepository
{
    private readonly EcommerceContext _ecommerceContext;
    public EtherWalletRepository(EcommerceContext ecommerceContext, DbContext context) : base(context)
    {
        _ecommerceContext = ecommerceContext;
    }

    public uint GetLastEtherWalletId()
    {
        return _ecommerceContext.EtherWallets.Select(x => x.Id).Last();
    }
}
