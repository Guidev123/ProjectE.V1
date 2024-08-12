using Microsoft.AspNetCore.Identity;

namespace OrderProject.Authentication.Data.Users
{
    public class UserRoles : IdentityUser<Guid>
    {
        public List<IdentityRole<Guid>>? Roles { get; set; }
    }
}
