﻿using Ecoinmerce.Application.Services.Token.Interfaces;
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

    public TokenVO GenerateRefreshToken(EcommerceManager admin)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                   new Claim("Username", admin.Username),
                   new Claim(ClaimTypes.Email, admin.Email),
            }),
            Expires = DateTime.Now.AddDays(2),
            SigningCredentials = _signingCredentials,
        };
        SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
        return new TokenVO(_tokenHandler.WriteToken(token), token);
    }

    public TokenVO GenerateAccessToken(EcommerceManager admin)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                   new Claim(ClaimTypes.Name, admin.FirstName),
                   new Claim("Username", admin.Username),
                   new Claim(ClaimTypes.Email, admin.Email),
                }),
            Expires = DateTime.Now.AddHours(12),
            SigningCredentials = _signingCredentials,
        };
        SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
        return new TokenVO(_tokenHandler.WriteToken(token), token);
    }

    public EcommerceManager HashPasswordWithNewSalt(EcommerceManager newAdmin, string nakedPassword)
    {
        try
        {
            newAdmin.Salt = RandomNumberGenerator.GetBytes(40);

            string hashedPassword = HashPassword(nakedPassword, newAdmin.Salt);

            newAdmin.Password = hashedPassword;
            return newAdmin;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public string ValidateTokenAndGetClaim(string token, string claimName)
    {
        return ValidateTokenAndGetClaim(token, _key, claimName);
    }
}
