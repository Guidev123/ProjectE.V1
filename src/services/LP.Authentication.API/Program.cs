using LP.Authentication.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddEnvMiddleware();
builder.AddDbContextMiddleware();
builder.AddSwaggerMiddleware();


var app = builder.Build();

app.UseSwaggerConfig();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
