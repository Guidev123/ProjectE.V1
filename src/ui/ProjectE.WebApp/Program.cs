using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ProjectE.WebApp;
using ProjectE.WebApp.Middlewares;
using ProjectE.WebApp.Security;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
WebConfiguration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddResolveDependenciesMiddleware();

builder.Services.AddHttpClient(WebConfiguration.HTTP_CLIENT_NAME, opt =>
{
    opt.BaseAddress = new Uri(WebConfiguration.BackendUrl);
}).AddHttpMessageHandler<CookieHandler>();

await builder.Build().RunAsync();
