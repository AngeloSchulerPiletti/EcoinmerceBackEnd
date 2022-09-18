using Ecoinmerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map.EcommerceMap;

public class EcommerceMap : IEntityTypeConfiguration<Ecommerce>
{
    public void Configure(EntityTypeBuilder<Ecommerce> builder)
    {
        builder.Property(x => x.WalletAddress)
            .HasMaxLength(42)
            .IsRequired();

        builder.Property(x => x.WebsiteDomain)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(60)
            .IsRequired();

        //builder.Property(x => x.EcommerceManager) // Tá certo?
        //    .IsRequired();

        builder.Property(x => x.FantasyName)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(x => x.Uf)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(x => x.Cnpj)
            .HasMaxLength(18)
            .IsRequired();

        builder.Property(x => x.AccessToken)
            .HasMaxLength(260)
            .IsRequired();
    }
}