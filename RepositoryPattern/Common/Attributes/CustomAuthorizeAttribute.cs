using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using RepositoryPattern.Dtos;

namespace RepositoryPattern.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private string[] Authorities { get; set; }

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
                context.Result = new ObjectResult(new ApiResponseFailed<Object>()
                {
                    status = "fail",
                    message = "permission denied",
                    error_code = "PERMISSION_DENIED"
                });
                context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            }

            var checkRoles = Authorities.Intersect(roles);// get intersect
            if (checkRoles.Count() == 0)
            {
                context.Result = new ObjectResult(new ApiResponseFailed<Object>()
                {
                    status = "fail",
                    message = "permission denied",
                    error_code = "PERMISSION_DENIED"
                });
                context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            }
        }
    }
}
