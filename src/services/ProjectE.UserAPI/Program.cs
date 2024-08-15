using ProjectE.UserAPI.Data;
using ProjectE.UserAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectE.UserAPI.DTOs;
using ProjectE.UserAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.AddEnvMiddleware();
builder.AddDbContextMiddleware();
builder.AddIdentityMiddleware();
builder.AddAuthenticationSchemeMiddleware();
builder.AddCorsMiddleware();
builder.Services.AddDocumentationMiddleware(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
    app.UseDevEnvironment();

app.UseSecurity();
//app.MapEndpoints();

app.MapGroup("ap/identity").WithTags("Identity").MapIdentityApi<User>();

app.MapPost("/register", async (RegisterDTO model, UserManager<User> userManager) =>
{
    if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Cpf))
    {
        return Results.BadRequest("Email, Senha e CPF são obrigatórios.");
    }

    var user = new User
    {
        UserName = model.Email,
        Email = model.Email,
        Cpf = new ProjectE.UserAPI.ValueObjects.Cpf(model.Cpf)
    };

    var result = await userManager.CreateAsync(user, model.Password);

    if (result.Succeeded)
    {
        return Results.Ok("Usuário registrado com sucesso!");
    }

    return Results.BadRequest(result.Errors);
});

app.UseHttpsRedirection();
app.Run();
