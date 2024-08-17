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
app.UseSecurity();
app.Run();
