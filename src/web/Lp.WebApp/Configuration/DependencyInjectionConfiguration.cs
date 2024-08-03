using LP.Shared.User;

namespace Lp.WebApp.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void AddResolveDependenciesMiddleware(this IServiceCollection services)
    {
        services.AddScoped<IUserManager, UserManager>();
    }
}
