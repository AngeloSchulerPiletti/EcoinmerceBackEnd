using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using Ecoinmerce.Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecoinmerce.Application.Services.Token;

public class TokenServiceEcommerce : BaseTokenService, ITokenServiceEcommerce
{
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly byte[] _accessTokenKey;
    private readonly byte[] _confirmationTokenKey;
    private readonly SigningCredentials _accessTokenSigningCredentials;
    private readonly SigningCredentials _confirmationTokenSigningCredentials;

    public TokenServiceEcommerce(TokenSecretsSetting tokenSecretsSetting)
    {
        _tokenHandler = new();

        _accessTokenKey = Encoding.ASCII.GetBytes(tokenSecretsSetting.Manager.AccessToken);
        _confirmationTokenKey = Encoding.ASCII.GetBytes(tokenSecretsSetting.Manager.ConfirmationToken);

        _accessTokenSigningCredentials = new(new SymmetricSecurityKey(_accessTokenKey), SecurityAlgorithms.HmacSha256Signature);
        _confirmationTokenSigningCredentials = new(new SymmetricSecurityKey(_confirmationTokenKey), SecurityAlgorithms.HmacSha256Signature);
    }

    public TokenVO GenerateApiToken(Ecommerce ecommerce, int validityInDays)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, ecommerce.Email),
            }),
            Expires = DateTime.Now.AddDays(validityInDays),
            SigningCredentials = _accessTokenSigningCredentials,
        };
        SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
        return new TokenVO(_tokenHandler.WriteToken(token), token);
    }

    public TokenVO GenerateConfirmationToken(Ecommerce ecommerce)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, ecommerce.Email),
                new Claim(ClaimTypes.Name, ecommerce.FantasyName)
            }),
            Expires = DateTime.Now.AddDays(90),
            SigningCredentials = _confirmationTokenSigningCredentials,
        };
        SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
        return new TokenVO(_tokenHandler.WriteToken(token), token);
    }

    public Claim GetEmailFromToken(string token)
    {
        JwtSecurityToken tokenData = _tokenHandler.ReadJwtToken(token);
        return tokenData.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
    }

    public JwtSecurityToken ValidateAccessToken(string token)
    {
        return ValidateToken(token, _accessTokenKey);
    }

    public JwtSecurityToken ValidateConfirmationToken(string token)
    {
        return ValidateToken(token, _confirmationTokenKey);
    }
}