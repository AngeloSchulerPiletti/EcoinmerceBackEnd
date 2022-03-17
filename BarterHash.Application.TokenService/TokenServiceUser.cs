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
    public class TokenServiceUser : ITokenServiceUser
    {
        private readonly IConfiguration _configuration;

        public TokenServiceUser(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenVO GenerateRefreshToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_configuration.GetSection("UserTokenSecret").Value);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenVO(tokenHandler.WriteToken(token), token);
        }

        public TokenVO GenerateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_configuration.GetSection("UserTokenSecret").Value);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                   new Claim(ClaimTypes.Name, user.Name),
                   new Claim("UserName", user.UserName),
                   new Claim(ClaimTypes.Email, user.Email),
                   new Claim(ClaimTypes.Role, user.Role),
                   new Claim("EcommerceId", user.EcommerceId.ToString()!),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenVO(tokenHandler.WriteToken(token), token);
        }
    }
}
