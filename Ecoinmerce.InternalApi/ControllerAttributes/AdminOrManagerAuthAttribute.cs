using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.InternalApi.ControllerAttributes;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AdminOrManagerAuthAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        EcommerceManager manager = (EcommerceManager)context.HttpContext.Items["Manager"];
        EcommerceAdmin admin = (EcommerceAdmin)context.HttpContext.Items["Admin"];
        bool isAccessTokenExpired = (bool)context.HttpContext.Items["IsAccessTokenExpired"];
        bool isAccessTokenValid = (bool)context.HttpContext.Items["IsAccessTokenValid"];

        if (admin == null && manager == null)
            context.Result = new JsonResult(new MessageBagVO("Faça o login para acessar", "Unauthorized", true, "L004")) { StatusCode = StatusCodes.Status401Unauthorized };
        else if (!isAccessTokenValid)
            context.Result = new JsonResult(new MessageBagVO("Token inválido", "Unauthorized", true, "L005")) { StatusCode = StatusCodes.Status401Unauthorized };
        else if (isAccessTokenExpired)
            context.Result = new JsonResult(new MessageBagVO("Token válido, mas já expirou", "Unauthorized", true, "L006")) { StatusCode = StatusCodes.Status401Unauthorized };
    }
}