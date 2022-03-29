using BarterHash.Domain.Entities.Ecommerce;
using BarterHash.Domain.Objects.DTO.Ecommerce;

namespace BarterHash.Infra.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User CheckPrimaryKeys(NewUserDTO newUserDTO);
        public User SignUpWithNewEcommerce(NewUserAndEcommerceDTO newUserAndEcommerceDTO);
        public User VerifyEmail(string tokenConfirmation);

        // Create user without ecommerce

        // Invite new user with X role
        // Update accessToken
        // Check accessToken 
    }
}
