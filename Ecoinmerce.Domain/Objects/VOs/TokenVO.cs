using Microsoft.IdentityModel.Tokens;

namespace Ecoinmerce.Domain.Objects.VOs
{
    public class TokenVO
    {
        public readonly string Token;
        public readonly SecurityToken TokenData;

        public TokenVO(string token, SecurityToken tokenData)
        {
            Token = token;
            TokenData = tokenData;
        }
    }
}
