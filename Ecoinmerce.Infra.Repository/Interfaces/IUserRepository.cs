using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTO.EcommerceDTO;

namespace Ecoinmerce.Infra.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User GetUser(NewUserDTO newUserDTO);

        /// <summary>
        /// Creates a user and a new ecommerce as its manager. 
        /// </summary>
        /// <param name="ecommerce">Ecommerce entity to be persisted</param>
        /// <param name="user">User entity to be persisted</param>
        /// <returns>Returns the public data of a User in DTO format</returns>
        public PublicUserDTO SignUpWithNewEcommerce(Ecommerce ecommerce, User user);

        /// <summary>
        /// Verifies the user confirmation token sent to the user's email.
        /// <br/>
        /// It also consider the token expiration date, and if the token belongs to the user
        /// </summary>
        /// <param name="tokenConfirmation">JWT Bearer Token</param>
        /// <returns>Returns the public user data if the email is verified</returns>
        public PublicUserDTO VerifyEmail(string tokenConfirmation);

        //TODO: Create user without ecommerce

        //TODO: Invite new user with X role
        //TODO: Update accessToken
        //TODO: Check accessToken 
    }
}
