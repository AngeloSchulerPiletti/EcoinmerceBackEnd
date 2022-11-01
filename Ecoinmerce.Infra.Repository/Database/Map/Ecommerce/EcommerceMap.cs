using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Respository.Database.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map;

public class EcommerceMap : CreateBaseTimestampEntityMap<Ecommerce>, IEntityTypeConfiguration<Ecommerce>
{
    public new void Configure(EntityTypeBuilder<Ecommerce> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Email)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(x => x.FantasyName)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(x => x.Cnpj)
            .HasMaxLength(18)
            .IsRequired();

        builder.Property(x => x.Cep)
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(x => x.Phone)
            .HasMaxLength(12);

        builder.Property(x => x.SocialReason)
            .HasMaxLength(128);

        builder.Property(x => x.Website)
            .HasMaxLength(600)
            .IsRequired();
    }
}