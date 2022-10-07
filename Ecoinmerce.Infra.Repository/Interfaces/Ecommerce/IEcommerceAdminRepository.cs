using Ecoinmerce.Domain.Entities;

namespace Ecoinmerce.Infra.Repository.Interfaces;

public interface IEcommerceAdminRepository : IGenericRepository<EcommerceAdmin>
{
    public EcommerceAdmin GetByEmail(string email);
}
