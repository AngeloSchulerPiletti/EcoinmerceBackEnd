using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Ecoinmerce.Application.Services.Token.Interfaces;

public interface ITokenServiceEcommerceAdmin
{
    public TokenVO GenerateAccessToken(EcommerceAdmin admin);
    public TokenVO GenerateConfirmationToken(EcommerceAdmin admin);
    public TokenVO GenerateRefreshToken(EcommerceAdmin admin);
    public Claim GetEmailFromToken(string token);
    public string HashPassword(string nakedPassword, byte[] salt);
    public bool HashPasswordWithNewSalt(ref EcommerceAdmin newEcommerceAdmin, string nakedPassword);
    public JwtSecurityToken ValidateAccessToken(string token);
    public JwtSecurityToken ValidateConfirmationToken(string token);
    public JwtSecurityToken ValidateRefreshToken(string token);
}
