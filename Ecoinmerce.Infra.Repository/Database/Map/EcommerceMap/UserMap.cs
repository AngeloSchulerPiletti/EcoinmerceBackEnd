using Ecoinmerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map.EcommerceMap
{
    public class UserMap : IEntityTypeConfiguration<EcommerceAdmin>
    {
        public void Configure(EntityTypeBuilder<EcommerceAdmin> builder)
        {
            builder.Property(x => x.Username)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.TokenConfirmation)
                .HasMaxLength(260);

            builder.Property(x => x.Password)
                .HasMaxLength(260)
                .IsRequired();

            builder.Property(x => x.EcommerceId)
                .IsRequired();

            builder.Property(x => x.AccessToken)
                .HasMaxLength(700)
                .IsRequired();

            builder.Property(x => x.RefreshToken)
                .HasMaxLength(260)
                .IsRequired();

            builder.Property(x => x.Salt)
                .HasMaxLength(50)
                .IsRequired();
        }
    }

}
