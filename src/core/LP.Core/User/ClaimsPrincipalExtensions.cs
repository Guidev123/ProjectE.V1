using System.Security.Claims;

namespace LP.Core.User;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null) throw new ArgumentException(nameof(principal));

        var claim = principal.FindFirst("sub");
        if (claim is not null) return claim.Value;

        return string.Empty;
    }

    public static string GetUserEmail(this ClaimsPrincipal principal)
    {
        if (principal == null) throw new ArgumentException(nameof(principal));

        var claim = principal.FindFirst("email");
        if (claim is not null) return claim.Value;

        return string.Empty;
    }

    public static string GetUserToken(this ClaimsPrincipal principal)
    {
        if (principal == null) throw new ArgumentException(nameof(principal));

        var claim = principal.FindFirst("JWT");
        if (claim is not null) return claim.Value;

        return string.Empty;
    }
}
