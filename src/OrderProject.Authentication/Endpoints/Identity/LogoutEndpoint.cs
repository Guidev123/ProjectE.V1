using Microsoft.AspNetCore.Identity;
using OrderProject.Authentication.Application;
using OrderProject.Authentication.Data.Users;
using OrderProject.Domain.Entities.Identity;

namespace OrderProject.Authentication.Endpoints.Identity
{
    public class LogoutEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app
                .MapPost("/logout", HandleAsync)
                .RequireAuthorization();

        private static async Task<IResult> HandleAsync(SignInManager<UserRoles> signInManager)
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        }
    }
}
