using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using System.IdentityModel.Tokens.Jwt;

namespace Ecoinmerce.Application.Services.Token.Interfaces;

public interface ITokenServiceEcommerceManager
{
    public TokenVO GenerateAccessToken(EcommerceManager user);
    public TokenVO GenerateRefreshToken(EcommerceManager user);
    public string HashPassword(string nakedPassword, byte[] salt);
    public EcommerceManager HashPasswordWithNewSalt(EcommerceManager newEcommerceManager, string nakedPassword);
    public string ValidateTokenAndGetClaim(string token, string claimName);
}
