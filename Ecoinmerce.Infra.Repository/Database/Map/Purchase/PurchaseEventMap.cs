using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Respository.Database.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map;

public class PurchaseEventMap : CreateBaseTimestampEntityMap<PurchaseEvent>, IEntityTypeConfiguration<PurchaseEvent>
{
    public new void Configure(EntityTypeBuilder<PurchaseEvent> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.PurchaseIdentifier)
            .HasMaxLength(70)
            .IsRequired();

        builder.Property(x => x.AmountPaidInEther)
            .HasColumnType("decimal")
            .HasPrecision(18, 28) //This is probably wrong
            .IsRequired();

        builder.Property(x => x.PaidAt)
            .IsRequired();
    }

}
