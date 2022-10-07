using Ecoinmerce.Application.Services.Interfaces;
using Ecoinmerce.Domain.Objects.DTOs.Requests;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace EcoinmerceInfra.Api.Management.ControllerAttributes;

[AttributeUsage(AttributeTargets.Method)]
public class PaginationAttribute : TypeFilterAttribute
{
    public PaginationAttribute() : base(typeof(PaginationFilter)) { }

    private class PaginationFilter : IActionFilter
    {
        private readonly IPaginationService _paginationService;

        public PaginationFilter(IPaginationService paginationService)
        {
            _paginationService = paginationService;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string page = context.HttpContext.Request.Query["page"];
            string limit = context.HttpContext.Request.Query["limit"];

            if (page != null && limit != null)
            {
                MessageBagSingleEntityVO<PaginationDTO> messageBagPagination =
                    _paginationService.MapPagination(int.Parse(page),
                                                     int.Parse(limit));

                if (messageBagPagination.IsError)
                    context.Result = new JsonResult(messageBagPagination) { StatusCode = (int?)HttpStatusCode.BadRequest };
                else
                    context.HttpContext.Items.Add("Pagination", messageBagPagination.Entity);
            }
            else context.Result = new JsonResult(new MessageBagVO("Paginação inválida", "Erro", true));
        }
    }
}
