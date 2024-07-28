using LP.Authentication.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LP.Authentication.API.Configuration
{
    public static class ApiConfiguration
    {
        public static void AddDbContextMiddleware(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AuthenticationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty));

            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthenticationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
