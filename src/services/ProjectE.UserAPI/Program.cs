using ProjectE.UserAPI.Middlewares;
using ProjectE.UserAPI.Endpoints;
using Microsoft.AspNetCore.Identity;
using ProjectE.Core.Commands.Account;
using ProjectE.UserAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.AddEnvMiddleware();
builder.AddDbContextMiddleware();
builder.AddIdentityMiddleware();
builder.AddAuthenticationSchemeMiddleware();
builder.AddCorsMiddleware();
builder.Services.AddDocumentationMiddleware(builder.Configuration);

var app = builder.Build();
app.UseDevEnvironment();
app.MapEndpoints();

var identityGroup = app.MapGroup("/api/custom-identity").WithTags("Identity");

// Mapeando o endpoint de registro personalizado dentro do grupo
identityGroup.MapPost("/register", async (RegisterCommand model, UserManager<User> userManager) =>
{
    if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Cpf))
    {
        return Results.BadRequest();
    }

    var user = new User
    {
        UserName = model.Email,
        Email = model.Email,
        Cpf = new(model.Cpf)
    };

    var result = await userManager.CreateAsync(user, model.Password);

    if (result.Succeeded)
    {
        return Results.Ok();
    }

    return Results.BadRequest(result.Errors);
});

app.UseSecurity();
app.Run();
