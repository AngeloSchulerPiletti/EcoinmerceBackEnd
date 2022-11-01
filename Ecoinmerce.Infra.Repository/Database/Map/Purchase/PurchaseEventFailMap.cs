using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Respository.Database.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map;

public class PurchaseEventFailMap : CreateBaseTimestampEntityMap<PurchaseEventFail>, IEntityTypeConfiguration<PurchaseEventFail>
{
    public new void Configure(EntityTypeBuilder<PurchaseEventFail> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.LogAddress)
            .HasMaxLength(42)
            .IsRequired();

        builder.Property(x => x.Observation)
           .HasMaxLength(2000);
    }

}
