using Ecoinmerce.Domain.Entities;

namespace Ecoinmerce.Infra.Repository.Interfaces;

public interface IEcommerceManagerRepository : IGenericRepository<EcommerceManager>
{
    public EcommerceManager GetByEmail(string email);
}
