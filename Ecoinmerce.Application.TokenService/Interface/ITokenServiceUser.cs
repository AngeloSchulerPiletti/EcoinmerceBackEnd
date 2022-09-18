using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VO;
using System.Security.Claims;

namespace Ecoinmerce.Application.TokenService.Interface
{
    public interface ITokenServiceUser
    {
        /// <summary>
        /// Get the email claim from a given confirmation token
        /// </summary>
        /// <param name="token">JWT Bearer Token</param>
        /// <returns>A claim containing the email</returns>
        public Claim GetEmailFromConfirmationToken(string token);
        public TokenVO GenerateAccessToken(User user);
        public TokenVO GenerateRefreshToken(User user);
        public TokenVO GenerateConfirmationToken(User user);

        /// <summary>
        /// <list>
        /// <item>Generates a Salt to the User</item>
        /// <item>Hashes the naked password</item>
        /// </list>
        /// </summary>
        /// <param name="newUser">The new user as User entity</param>
        /// <param name="nakedPassword">The new user naked password</param>
        /// <returns>Return the User with the hashed password</returns>
        public User HashPasswordWithNewSalt(User newUser, string nakedPassword);
    }
}
