using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Project.Core.DTOs;

namespace Project.API.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class CustomAuthorize : AuthorizeAttribute, IAuthorizationFilter
{
    public string[] Authorities { get; set; }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var roles = context.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();

        //no Authorize
        if (Authorities == null || Authorities.Length == 0)
            return;

        //token not send
        if (roles.Count == 0)
        {
            context.Result = new ObjectResult(CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status403Forbidden, "permission denied"));
            context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
        }

        var checkRoles = Authorities.Intersect(roles);// get intersect
        if (!checkRoles.Any())
        {
            context.Result = new ObjectResult(CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status403Forbidden, "permission denied"));
            context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
        }
    }
}
