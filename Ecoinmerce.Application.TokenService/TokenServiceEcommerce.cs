using Ecoinmerce.Application.TokenService.Interface;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecoinmerce.Application.TokenService
{
    public class TokenServiceEcommerce : ITokenServiceEcommerce
    {
        //private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly byte[] _key;
        private readonly SigningCredentials _signingCredentials;

        public TokenServiceEcommerce(IConfiguration configuration)
        {
            //_configuration = configuration;
            _tokenHandler = new();

            string tokenSecret = configuration.GetSection("EcommerceTokenSecret").Value;

            _key = Encoding.ASCII.GetBytes(tokenSecret);
            _signingCredentials = new(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature);
        }

        public TokenVO GenerateToken(Ecommerce ecommerce)
        {
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", ecommerce.Id.ToString()),
                   new Claim("WalletAddress", ecommerce.WalletAddress),
                }),
                SigningCredentials = _signingCredentials,
                Expires = DateTime.MaxValue,
            };
            SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
            return new TokenVO(_tokenHandler.WriteToken(token), token);
        }
    }
}
