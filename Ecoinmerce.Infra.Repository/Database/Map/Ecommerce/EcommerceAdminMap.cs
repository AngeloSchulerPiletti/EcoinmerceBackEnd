using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Respository.Database.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map
{
    public class EcommerceAdminMap : CreateBaseTimestampAgentEntityMap<EcommerceAdmin>, IEntityTypeConfiguration<EcommerceAdmin>
    {
        public new void Configure(EntityTypeBuilder<EcommerceAdmin> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Username)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

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

            builder.Property(x => x.ConfirmationToken)
                .HasMaxLength(260);

            builder.Property(x => x.Salt)
                .HasMaxLength(50)
                .IsRequired();
        }
    }

}
