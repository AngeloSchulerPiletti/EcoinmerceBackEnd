using Ecoinmerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map;

public class PurchaseMap : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.Property(x => x.EcommerceWalletAddress)
            .HasMaxLength(42)
            .IsRequired();

        builder.Property(x => x.CostumerWalletAddress)
            .HasMaxLength(42)
            .IsRequired();

        builder.Property(x => x.BlockHash)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(x => x.TransactionHash)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(x => x.Observation)
            .HasMaxLength(300);



        /* 
         * @todo rules: 
         * 
         * Para um EcommerceWalletAddress X, não pode haver mais de uma compra com PurchaseIdentifier Y
         * 
         * Pelo menos PurchaseEvent ou PurchaseNotice precisa estar preenchido e, 
         * quando estiverem, seus "bools" não podem ser falso e existem regras 
         * internas em cada um que precisam ser respeitadas (ver para usar fluent 
         * validation)
         * 
         */
    }

}
