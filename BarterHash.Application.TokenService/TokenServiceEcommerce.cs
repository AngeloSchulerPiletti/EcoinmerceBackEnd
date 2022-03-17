using BarterHash.Application.TokenService.Interface;
using BarterHash.Domain.Entities.Ecommerce;
using BarterHash.Domain.Objects.VO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BarterHash.Application.TokenService
{
    public class TokenServiceEcommerce : ITokenServiceEcommerce
    {
        private readonly IConfiguration _configuration;

        public TokenServiceEcommerce(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenVO GenerateToken(Ecommerce ecommerce)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_configuration.GetSection("EcommerceTokenSecret").Value);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", ecommerce.Id.ToString()),
                   new Claim("WalletAddress", ecommerce.WalletAddress),
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.MaxValue,
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenVO(tokenHandler.WriteToken(token), token);
        }
    }
}
