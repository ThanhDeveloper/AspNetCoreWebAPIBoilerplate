using System.Security.Claims;

namespace Project.Service.Common.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static T GetUserId<T>(ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        var loggedInUserId = principal.Claims.First(x => x.Type == Constants.ClaimTypeUserId).Value;

        if (typeof(T) == typeof(string))
        {
            return (T)Convert.ChangeType(loggedInUserId, typeof(T));
        }

        if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
        {
            return (T)Convert.ChangeType(loggedInUserId, typeof(T));
        }

        throw new Exception("Invalid type provided");
    }

    public static string GetUserName(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return principal.Claims.First(x => x.Type == ClaimTypes.Name).Value;
    }

    public static string GetEmail(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return principal.Claims.First(x => x.Type == ClaimTypes.Email).Value;
    }
}