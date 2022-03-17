using Microsoft.IdentityModel.Tokens;

namespace BarterHash.Domain.Objects.VO
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
