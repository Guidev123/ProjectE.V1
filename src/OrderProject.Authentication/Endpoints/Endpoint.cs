using OrderProject.Authentication.Application;
using OrderProject.Authentication.Data.Users;
using OrderProject.Authentication.Endpoints.Identity;
using OrderProject.Domain.Entities.Identity;

namespace OrderProject.Authentication.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "Está funcinando!" });

            endpoints.MapGroup("api/identity").WithTags("Identity").MapIdentityApi<UserRoles>();
            endpoints.MapGroup("api/identity").WithTags("Identity").MapEndpoint<LogoutEndpoint>().MapEndpoint<GetRolesEndpoint>();
        }


        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
