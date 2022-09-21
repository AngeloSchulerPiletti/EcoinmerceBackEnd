using Ecoinmerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map
{
    public class PurchaseCheckMap : IEntityTypeConfiguration<PurchaseCheck>
    {
        public void Configure(EntityTypeBuilder<PurchaseCheck> builder)
        {
        }

    }
}
