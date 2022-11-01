using Ecoinmerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map.EcommerceMap;

public class EcommerceManagerMap : IEntityTypeConfiguration<EcommerceManager>
{
    public void Configure(EntityTypeBuilder<EcommerceManager> builder)
    {
        builder.Property(x => x.FirstName)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(x => x.Cpf)
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(x => x.Username)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(x => x.AccessToken)
            .HasMaxLength(700)
            .IsRequired();

        builder.Property(x => x.RefreshToken)
            .HasMaxLength(260)
            .IsRequired();

        builder.Property(x => x.ConfirmationToken)
            .HasMaxLength(260)
            .IsRequired();

        builder.Property(x => x.IsEmailConfirmed)
            .IsRequired();

        builder.Property(x => x.Cellphone)
            .HasMaxLength(13)
            .IsRequired();

        builder.Property(x => x.Phone)
            .HasMaxLength(12)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.Salt)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();
    }
}
