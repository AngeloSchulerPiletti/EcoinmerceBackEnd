using BarterHash.Domain.Entities.Ecommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarterHash.Infra.Repository.Database.Map.EcommerceMap
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserName)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.Role)
                .HasMaxLength(30)
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
                .HasMaxLength(260)
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
