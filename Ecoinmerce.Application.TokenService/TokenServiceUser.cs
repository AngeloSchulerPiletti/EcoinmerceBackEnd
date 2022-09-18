using Ecoinmerce.Application.TokenService.Interface;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VO;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ecoinmerce.Application.TokenService
{
    public class TokenServiceUser : ITokenServiceUser
    {
        //private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly byte[] _key;
        private readonly SigningCredentials _signingCredentials;

        public TokenServiceUser(IConfiguration configuration)
        {
            //_configuration = configuration;
            _tokenHandler = new();

            string tokenSecret = configuration.GetSection("UserTokenSecret").Value;

            _key = Encoding.ASCII.GetBytes(tokenSecret);
            _signingCredentials = new(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature);
        }

        public TokenVO GenerateRefreshToken(User user)
        {
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]
                {
                   new Claim("UserName", user.UserName),
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
                   new Claim(ClaimTypes.Name, user.Name),
                   new Claim("UserName", user.UserName),
                   new Claim(ClaimTypes.Email, user.Email),
                   new Claim(ClaimTypes.Role, user.Role),
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

        public Claim GetEmailFromConfirmationToken(string token)
        {
            JwtSecurityToken tokenData = _tokenHandler.ReadJwtToken(token);
            return tokenData.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
        }

        public User HashPasswordWithNewSalt(User newUser, string nakedPassword)
        {
            try
            {
                newUser.Salt = RandomNumberGenerator.GetBytes(40);

                byte[] nakedPasswordBytes = Encoding.ASCII.GetBytes(nakedPassword);

                string hashedPassword = Convert.ToBase64String(
                    KeyDerivation.Pbkdf2(
                        password: nakedPassword,
                        salt: newUser.Salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8
                        )
                    );

                newUser.Password = hashedPassword;
                return newUser;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
