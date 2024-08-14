using HealthLife.UserAPI.Data;
using HealthLife.UserAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectE.UserAPI.DTOs;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityCore<User>().AddRoles<IdentityRole<long>>().AddEntityFrameworkStores<UserDbContext>().AddApiEndpoints();

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddBearerToken();
builder.Services.AddAuthorization();



var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
        Cpf = new HealthLife.UserAPI.ValueObjects.Cpf(model.Cpf)
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
