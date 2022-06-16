using Microsoft.AspNetCore.Authorization;

namespace Project.API.Filters;

public class AuthorizeRolesAttribute : AuthorizeAttribute
{
    public AuthorizeRolesAttribute(params string[] roles) : base()
    {
        Roles = string.Join(",", roles);
    }
}