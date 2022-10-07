using Ecoinmerce.Application.Services.Token.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Ecoinmerce.Application.Services.Token
{
    public abstract class BaseTokenService
    {
        public static string HashPassword(string nakedPassword, byte[] salt)
        {
            return Convert.ToBase64String(
                    KeyDerivation.Pbkdf2(
                        password: nakedPassword,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8
                        )
                    );
        }

        public static JwtSecurityToken ValidateToken(string token, byte[] key)
        {
            if (token == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return (JwtSecurityToken)validatedToken;
            }
            catch
            {
                return null;
            }
        }

        protected string ValidateTokenAndGetClaim(string token, byte[] key, string claimName)
        {
            try
            {
                JwtSecurityToken jwtToken = ValidateToken(token, key);
                if (jwtToken == null) return null;
                return jwtToken.Claims.First(x => x.Type == claimName).Value;
            }
            catch
            {
                return null;
            }
        }
    }
}
