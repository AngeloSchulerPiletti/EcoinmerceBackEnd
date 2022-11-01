using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Respository.Database.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map;

public class PurchaseCheckMap : CreateBaseTimestampAgentEntityMap<PurchaseCheck>, IEntityTypeConfiguration<PurchaseCheck>
{
    public new void Configure(EntityTypeBuilder<PurchaseCheck> builder)
    {
        base.Configure(builder);
    }

}
