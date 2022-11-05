using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Ecoinmerce.Application.Services.Token.Interfaces;

public interface ITokenServiceEcommerce
{
    public TokenVO GenerateApiToken(Ecommerce ecommerce, int validityInDays);
    public TokenVO GenerateConfirmationToken(Ecommerce ecommerce);
    public Claim GetEmailFromToken(string token);
    public JwtSecurityToken ValidateAccessToken(string token);
    public JwtSecurityToken ValidateConfirmationToken(string token);
}
