using BarterHash.Domain.Entities.Ecommerce;
using BarterHash.Domain.Objects.VO;
using System.Security.Claims;

namespace BarterHash.Application.TokenService.Interface
{
    public interface ITokenServiceUser
    {
        public Claim? GetEmailFromConfirmationToken(string token);
        public TokenVO GenerateAccessToken(User user);
        public TokenVO GenerateRefreshToken(User user);
        public TokenVO GenerateConfirmationToken(User user);
        //TODO: Generate token for email confirmation
    }
}
