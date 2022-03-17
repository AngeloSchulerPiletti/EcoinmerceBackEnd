using BarterHash.Domain.Entities.Ecommerce;
using BarterHash.Domain.Objects.VO;

namespace BarterHash.Application.TokenService.Interface
{
    public interface ITokenServiceEcommerce
    {
        public TokenVO GenerateToken(Ecommerce user);
    }
}
