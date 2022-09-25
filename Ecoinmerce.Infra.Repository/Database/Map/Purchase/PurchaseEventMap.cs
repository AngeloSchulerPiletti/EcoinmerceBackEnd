using Ecoinmerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map
{
    public class PurchaseEventMap : IEntityTypeConfiguration<PurchaseEvent>
    {
        public void Configure(EntityTypeBuilder<PurchaseEvent> builder)
        {
            builder.Property(x => x.PurchaseIdentifier)
                .HasMaxLength(70)
                .IsRequired();

            //builder.Property(x => x.AmountPaidInGwei)
            //    .HasColumnType("decimal")
            //    .HasPrecision(28, 18)
            //    .IsRequired();

            builder.Property(x => x.PaidAt)
                .IsRequired();
        }

    }
}
