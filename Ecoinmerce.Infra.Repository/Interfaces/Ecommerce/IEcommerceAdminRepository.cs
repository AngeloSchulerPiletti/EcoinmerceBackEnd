using Ecoinmerce.Domain.Entities;

namespace Ecoinmerce.Infra.Repository.Interfaces;

public interface IEcommerceAdminRepository : IGenericRepository<EcommerceAdmin>
{
    public bool AnyUsername(string username);
    public EcommerceAdmin GetByEmail(string email);
}
