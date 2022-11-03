using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using System.Security.Claims;

namespace Ecoinmerce.Application.Services.Token.Interfaces;

public interface ITokenServiceEcommerce
{
    public TokenVO GenerateApiToken(Ecommerce ecommerce, int validityInDays);
    public TokenVO GenerateConfirmationToken(Ecommerce ecommerce);
    public Claim GetEmailFromApiToken(string token);
    public Claim GetEmailFromConfirmationToken(string token);
    public string ValidateTokenAndGetClaim(string token, string claimName);
}
