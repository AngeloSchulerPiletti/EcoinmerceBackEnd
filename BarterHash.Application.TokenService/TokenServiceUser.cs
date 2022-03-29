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
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly byte[] _key;
        private readonly SigningCredentials _signingCredentials;

        public TokenServiceUser(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenHandler = new();
            _key = Encoding.ASCII.GetBytes(_configuration.GetSection("UserTokenSecret").Value);
            _signingCredentials = new(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature);
        }

        public TokenVO GenerateRefreshToken(User user)
        {
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = _signingCredentials,
            };
            SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
            return new TokenVO(_tokenHandler.WriteToken(token), token);
        }

        public TokenVO GenerateAccessToken(User user)
        {
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
                SigningCredentials = _signingCredentials,
            };
            SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
            return new TokenVO(_tokenHandler.WriteToken(token), token);
        }

        public TokenVO GenerateConfirmationToken(User user)
        {
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = _signingCredentials,
            };
            SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
            return new TokenVO(_tokenHandler.WriteToken(token), token);
        }

        public Claim? GetEmailFromConfirmationToken(string token)
        {
            JwtSecurityToken tokenData = _tokenHandler.ReadJwtToken(token);
            return tokenData.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
        }
    }
}
