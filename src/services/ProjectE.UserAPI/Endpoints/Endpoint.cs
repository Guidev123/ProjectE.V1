using Microsoft.AspNetCore.Identity;
using ProjectE.Core.Commands.Account;
using ProjectE.UserAPI.Endpoints.Identity;
using ProjectE.UserAPI.Models;

namespace ProjectE.UserAPI.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("api/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        endpoints.MapGroup("api/identity")
            .WithTags("Identity")
            .MapEndpoint<LogoutEndpoint>()
            .MapEndpoint<GetRolesEndpoint>()
            .MapEndpoint<RegisterCustomEndpoint>();

    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
