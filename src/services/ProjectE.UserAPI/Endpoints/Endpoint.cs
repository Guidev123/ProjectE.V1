using ProjectE.UserAPI.Endpoints.Identity;
using ProjectE.UserAPI.Models;

namespace ProjectE.UserAPI.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("/")
    .WithTags("Health Check")
    .MapGet("/", () => new { message = "Está funcinando!" });

        endpoints.MapGroup("api/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        endpoints.MapGroup("api/identity")
            .WithTags("Identity")
            .MapEndpoint<LogoutEndpoint>()
            .MapEndpoint<GetRolesEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
