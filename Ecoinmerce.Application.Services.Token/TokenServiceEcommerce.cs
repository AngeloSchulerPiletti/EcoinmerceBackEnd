using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecoinmerce.Application.Services.Token;

public class TokenServiceEcommerce : BaseTokenService, ITokenServiceEcommerce
{
    //private readonly IConfiguration _configuration;
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly byte[] _key;
    private readonly SigningCredentials _signingCredentials;

    public TokenServiceEcommerce(IConfiguration configuration) : base()
    {
        //_configuration = configuration;
        _tokenHandler = new();

        string tokenSecret = configuration.GetSection("EcommerceTokenSecret").Value;

        _key = Encoding.ASCII.GetBytes(tokenSecret);
        _signingCredentials = new(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature);
    }

    public TokenVO GenerateApiToken(Ecommerce ecommerce)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, ecommerce.Email),
            }),
            Expires = DateTime.Now.AddDays(90),
            SigningCredentials = _signingCredentials,
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
            SigningCredentials = _signingCredentials,
        };
        SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
        return new TokenVO(_tokenHandler.WriteToken(token), token);
    }

    public Claim GetEmailFromApiToken(string token)
    {
        JwtSecurityToken tokenData = _tokenHandler.ReadJwtToken(token);
        return tokenData.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
    }

    public Claim GetEmailFromConfirmationToken(string token)
    {
        JwtSecurityToken tokenData = _tokenHandler.ReadJwtToken(token);
        return tokenData.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
    }
}