﻿using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Ecoinmerce.Application.Services.Token.Interfaces;

public interface ITokenServiceEcommerceManager
{
    public TokenVO GenerateAccessToken(EcommerceManager manager);
    public TokenVO GenerateConfirmationToken(EcommerceManager manager);
    public TokenVO GenerateRefreshToken(EcommerceManager manager);
    public Claim GetEmailFromConfirmationToken(string token);
    public string HashPassword(string nakedPassword, byte[] salt);
    public bool HashPasswordWithNewSalt(ref EcommerceManager newEcommerceManager, string nakedPassword);
    public string ValidateTokenAndGetClaim(string token, string claimName);
    public JwtSecurityToken ValidateToken(string token);
}
