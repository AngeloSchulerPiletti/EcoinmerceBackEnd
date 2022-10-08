using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using System.IdentityModel.Tokens.Jwt;

namespace Ecoinmerce.Application.Services.Token.Interfaces;

public interface ITokenServiceEcommerceAdmin
{
    public TokenVO GenerateAccessToken(EcommerceAdmin user);
    public TokenVO GenerateRefreshToken(EcommerceAdmin user);
    public string HashPassword(string nakedPassword, byte[] salt);
    public EcommerceAdmin HashPasswordWithNewSalt(EcommerceAdmin newEcommerceAdmin, string nakedPassword);
    public string ValidateTokenAndGetClaim(string token, string claimName);
}
