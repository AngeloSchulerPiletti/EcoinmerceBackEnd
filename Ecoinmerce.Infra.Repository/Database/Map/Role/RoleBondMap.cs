using Ecoinmerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map;

public class RoleBondMap : IEntityTypeConfiguration<RoleBond>
{
    public void Configure(EntityTypeBuilder<RoleBond> builder)
    {
    }
}
