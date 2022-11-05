using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using Ecoinmerce.Domain.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ecoinmerce.Application.Services.Token;

public class TokenServiceEcommerceManager : BaseTokenService, ITokenServiceEcommerceManager
{
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly byte[] _accessTokenKey;
    private readonly byte[] _confirmationTokenKey;
    private readonly byte[] _refreshTokenKey;
    private readonly SigningCredentials _accessTokenSigningCredentials;
    private readonly SigningCredentials _confirmationTokenSigningCredentials;
    private readonly SigningCredentials _refreshTokenSigningCredentials;

    public TokenServiceEcommerceManager(TokenSecretsSetting tokenSecretsSetting) 
    {
        _tokenHandler = new();

        _accessTokenKey = Encoding.ASCII.GetBytes(tokenSecretsSetting.Manager.AccessToken);
        _confirmationTokenKey = Encoding.ASCII.GetBytes(tokenSecretsSetting.Manager.ConfirmationToken);
        _refreshTokenKey = Encoding.ASCII.GetBytes(tokenSecretsSetting.Manager.RefreshToken);

        _accessTokenSigningCredentials = new(new SymmetricSecurityKey(_accessTokenKey), SecurityAlgorithms.HmacSha256Signature);
        _confirmationTokenSigningCredentials = new(new SymmetricSecurityKey(_confirmationTokenKey), SecurityAlgorithms.HmacSha256Signature);
        _refreshTokenSigningCredentials = new(new SymmetricSecurityKey(_refreshTokenKey), SecurityAlgorithms.HmacSha256Signature);
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
            SigningCredentials = _accessTokenSigningCredentials,
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
            SigningCredentials = _confirmationTokenSigningCredentials,
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
            SigningCredentials = _refreshTokenSigningCredentials,
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

    public JwtSecurityToken ValidateAccessToken(string token)
    {
        return ValidateToken(token, _accessTokenKey);
    }

    public JwtSecurityToken ValidateConfirmationToken(string token)
    {
        return ValidateToken(token, _confirmationTokenKey);
    }

    public JwtSecurityToken ValidateRefreshToken(string token)
    {
        return ValidateToken(token, _refreshTokenKey);
    }
}
