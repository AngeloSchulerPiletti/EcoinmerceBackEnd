using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Respository.Database.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map;

public class PurchaseMap : CreateBaseTimestampAgentEntityMap<Purchase>, IEntityTypeConfiguration<Purchase>
{
    public new void Configure(EntityTypeBuilder<Purchase> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.EcommerceWalletAddress)
            .HasMaxLength(42)
            .IsRequired();

        builder.Property(x => x.CostumerWalletAddress)
            .HasMaxLength(42)
            .IsRequired();

        builder.Property(x => x.BlockHash)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(x => x.TransactionHash)
            .HasMaxLength(128)
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
