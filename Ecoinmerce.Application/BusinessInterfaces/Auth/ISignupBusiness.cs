using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTO.EcommerceDTO;
using Ecoinmerce.Domain.Objects.VO.Responses;

namespace Ecoinmerce.Application.BusinessInterfaces.Auth
{
    public interface ISignupBusiness
    {
        public MessageBagVO CheckIfUserNameAndEmailIsBeingUsed(NewUserDTO newUserDTO);

        /// <summary>
        /// Maps the NewUserDTO to the User Entity hashing the user's password
        /// </summary>
        /// <param name="newUserDTO">The new user data provider by the client</param>
        /// <returns>Returns a response message with the User entity</returns>
        public MessageBagSingleEntityVO<User> MapToEntityHashingPassword(NewUserDTO newUserDTO);
        public MessageBagSingleEntityVO<Ecommerce> MapToEntity(NewEcommerceDTO newEcommerceDTO);

        /// <summary>
        /// Saves already verified and completed User and Ecommerce entities
        /// </summary>
        /// <returns>Returns the User public data</returns>
        public MessageBagSingleEntityVO<PublicUserDTO> SaveConfiableNewUserAndEcommerce(User user, Ecommerce ecommerce);
    }
}
