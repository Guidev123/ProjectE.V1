using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using OrderProject.Authentication.Application;
using OrderProject.Authentication.Data.Users;
using OrderProject.Authentication.Endpoints;
using OrderProject.Authentication.Extensions;
using OrderProject.Authentication.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.AddEnvConfig();
builder.AddDbContextConfig();
builder.Services.AddSecurityConfig();
builder.AddCorsConfig();

builder.Services.AddSingleton<IEmailSender<UserRoles>, EmailSender>();

builder.Services.AddDocumentationConfig(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseConfigureDevEnvironment();

app.UseSecurity();
app.MapEndpoints();

app.Run();
