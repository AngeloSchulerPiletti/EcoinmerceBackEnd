using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Interfaces;

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

        string adminEmail = tokenServiceAdmin.ValidateTokenAndGetClaim(accessToken, "email");
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
        else
        {
            string managerEmail = tokenServiceManager.ValidateTokenAndGetClaim(accessToken, "email");
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

        context.Items["IsAccessTokenExpired"] = isAccessTokenExpired;
        context.Items["IsAccessTokenValid"] = isAccessTokenValid;

        await _next(context);
    }
}
