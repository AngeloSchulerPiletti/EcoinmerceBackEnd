using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VO;

namespace Ecoinmerce.Application.TokenService.Interface
{
    public interface ITokenServiceEcommerce
    {
        public TokenVO GenerateToken(Ecommerce ecommerce);
    }
}
