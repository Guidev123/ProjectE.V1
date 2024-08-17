using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using ProjectE.Core.Handlers;
using ProjectE.WebApp.Handler;
using ProjectE.WebApp.Security;

namespace ProjectE.WebApp.Middlewares
{
    public static class CustomMiddlewares
    {
        public static void AddResolveDependenciesMiddleware(this IServiceCollection services)
        {
            // AUTH
            services.AddScoped<CookieHandler>();
            services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
            services.AddScoped(x => (ICookieAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>());
            services.AddTransient<IAccountHandler, AccountHandler>();

            // THEME
            services.AddMudServices();
        }
    }
}
