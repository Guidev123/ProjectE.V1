
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LP.Shared.User;

public class UserManager(IHttpContextAccessor contextAccessor) : IUserManager
{
    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
    public string Name => _contextAccessor.HttpContext.User.Identity?.Name ?? string.Empty;
    public Guid GetId()
    {
        if (!IsAuthenticated()) return Guid.Empty;

        var userIdClaim = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out Guid userId)) return userId;

        return Guid.Empty;
    }
    public bool IsAuthenticated() => _contextAccessor.HttpContext.User.Identity?.IsAuthenticated ?? false;
    public string GetEmail() => IsAuthenticated() ? _contextAccessor.HttpContext.User.GetUserEmail() : string.Empty;
    public string GetToken() => IsAuthenticated() ? _contextAccessor.HttpContext.User.GetUserToken() : string.Empty;
    public IEnumerable<Claim> GetClaims() => _contextAccessor.HttpContext.User.Claims;
    public bool HasRole(string roleName) => _contextAccessor.HttpContext.User.IsInRole(roleName);
    public HttpContext GetHttpContextAccessor() => _contextAccessor.HttpContext;
}
