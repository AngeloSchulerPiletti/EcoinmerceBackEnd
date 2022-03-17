using BarterHash.Domain.Entities.Ecommerce;
using BarterHash.Domain.Objects.VO;

namespace BarterHash.Application.TokenService.Interface
{
    public interface ITokenServiceUser
    {
        public TokenVO GenerateToken(User user);
        public TokenVO GenerateRefreshToken(User user);
    }
}
