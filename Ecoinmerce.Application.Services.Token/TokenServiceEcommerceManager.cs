using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ecoinmerce.Application.Services.Token;

public class TokenServiceEcommerceManager : BaseTokenService, ITokenServiceEcommerceManager
{
    //private readonly IConfiguration _configuration;
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly byte[] _key;
    private readonly SigningCredentials _signingCredentials;

    public TokenServiceEcommerceManager(IConfiguration configuration) 
    {
        //_configuration = configuration;
        _tokenHandler = new();

        string tokenSecret = configuration.GetSection("EcommerceManagerTokenSecret").Value;

        _key = Encoding.ASCII.GetBytes(tokenSecret);
        _signingCredentials = new(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature);
    }

    public TokenVO GenerateAccessToken(EcommerceManager manager)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                   new Claim(ClaimTypes.Name, manager.FirstName),
                   new Claim("Username", manager.Username),
                   new Claim(ClaimTypes.Email, manager.Email),
                }),
            Expires = DateTime.Now.AddHours(12),
            SigningCredentials = _signingCredentials,
        };
        SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
        return new TokenVO(_tokenHandler.WriteToken(token), token);
    }

    public TokenVO GenerateConfirmationToken(EcommerceManager manager)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                    new Claim(ClaimTypes.Email, manager.Email)
                }),
            Expires = DateTime.Now.AddDays(2),
            SigningCredentials = _signingCredentials,
        };
        SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
        return new TokenVO(_tokenHandler.WriteToken(token), token);
    }

    public TokenVO GenerateRefreshToken(EcommerceManager manager)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                   new Claim("Username", manager.Username),
                   new Claim(ClaimTypes.Email, manager.Email),
            }),
            Expires = DateTime.Now.AddDays(2),
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

    public new string HashPassword(string nakedPassword, byte[] salt)
    {
        return BaseTokenService.HashPassword(nakedPassword, salt);
    }

    public bool HashPasswordWithNewSalt(ref EcommerceManager newManager, string nakedPassword)
    {
        try
        {
            newManager.Salt = RandomNumberGenerator.GetBytes(40);

            string hashedPassword = HashPassword(nakedPassword, newManager.Salt);

            newManager.Password = hashedPassword;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public JwtSecurityToken ValidateToken(string token)
    {
        return ValidateToken(token, _key);
    }

    public string ValidateTokenAndGetClaim(string token, string claimName)
    {
        return ValidateTokenAndGetClaim(token, _key, claimName);
    }

}
