using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LP.Shared.User;

public interface IUserManager
{
    string Name { get; }
    Guid GetId();
    string GetEmail();
    string GetToken();
    bool IsAuthenticated();
    bool HasRole(string roleName);
    IEnumerable<Claim> GetClaims();
    HttpContext? GetHttpContextAccessor();
}
