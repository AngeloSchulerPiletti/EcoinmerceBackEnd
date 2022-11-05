using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace Ecoinmerce.Infra.Api.Management.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context,
                                  IEcommerceAdminRepository adminRepository,
                                  ITokenServiceEcommerceAdmin tokenServiceAdmin,
                                  IEcommerceManagerRepository managerRepository,
                                  ITokenServiceEcommerceManager tokenServiceManager)
    {
        bool isAccessTokenExpired = true;
        bool isAccessTokenValid = false;

        string accessToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        JwtSecurityToken adminSecurityToken = tokenServiceAdmin.ValidateAccessToken(accessToken);
        if (adminSecurityToken != null)
        {
            string adminEmail = tokenServiceAdmin.GetEmailFromToken(accessToken).Value;
            if (adminEmail != null)
            {
                EcommerceAdmin admin = adminRepository.GetByEmail(adminEmail);
                if (admin != null)
                {
                    context.Items["Admin"] = admin;

                    if (admin.AccessTokenExpiry != null && admin.AccessTokenExpiry > DateTime.Now) isAccessTokenExpired = false;
                    if (admin.AccessToken != null && admin.AccessToken == accessToken) isAccessTokenValid = true;
                    if (isAccessTokenExpired || !isAccessTokenValid)
                    {
                        admin.CleanAccessToken();
                        adminRepository.SaveChanges();
                    }
                }
            }
        }
        else
        {
            JwtSecurityToken managerSecurityToken = tokenServiceManager.ValidateAccessToken(accessToken);
            if (managerSecurityToken != null)
            {
                string managerEmail = tokenServiceManager.GetEmailFromToken(accessToken).Value;
                if (managerEmail != null)
                {
                    EcommerceManager manager = managerRepository.GetByEmail(managerEmail);
                    if (manager != null)
                    {
                        context.Items["Manager"] = manager;

                        if (manager.AccessTokenExpiry != null && manager.AccessTokenExpiry > DateTime.Now) isAccessTokenExpired = false;
                        if (manager.AccessToken != null && manager.AccessToken == accessToken) isAccessTokenValid = true;
                        if (isAccessTokenExpired || !isAccessTokenValid)
                        {
                            manager.CleanAccessToken();
                            managerRepository.SaveChanges();
                        }
                    }
                }
            }
        }

        context.Items["IsAccessTokenExpired"] = isAccessTokenExpired;
        context.Items["IsAccessTokenValid"] = isAccessTokenValid;

        await _next(context);
    }
}
