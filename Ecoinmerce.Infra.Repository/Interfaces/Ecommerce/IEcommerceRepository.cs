using Ecoinmerce.Domain.Entities;

namespace Ecoinmerce.Infra.Repository.Interfaces;

public interface IEcommerceRepository : IGenericRepository<Ecommerce>
{
    public bool CnpjIsBeingUsed(string cnpj);
    public bool EmailIsBeingUsed(string email);
    public Ecommerce GetByEmail(string email);
    public Ecommerce GetByWalletAddress(string walletAddress);
    public int GetTotalApiCredentials(int ecommerceId);
}
