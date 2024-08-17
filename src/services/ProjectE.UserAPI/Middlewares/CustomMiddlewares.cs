using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectE.UserAPI.Data;
using ProjectE.UserAPI.Models;
using Swashbuckle.AspNetCore.Filters;

namespace ProjectE.UserAPI.Middlewares
{
    public static class CustomMiddlewares
    {
        public static void AddDbContextMiddleware(this WebApplicationBuilder builder) => builder.Services.AddDbContext<UserDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        public static void AddIdentityMiddleware(this WebApplicationBuilder builder) => builder.Services.AddIdentityCore<User>()
            .AddRoles<IdentityRole<long>>().AddEntityFrameworkStores<UserDbContext>().AddApiEndpoints();
        public static void AddEnvMiddleware(this WebApplicationBuilder builder) => builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        public static void AddDocumentationMiddleware(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Name = "Token",
                    Description = "Put your token: Bearer {token}",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });
                x.OperationFilter<SecurityRequirementsOperationFilter>();
                x.CustomSchemaIds(n => n.FullName);
            });
        }
        public static void AddAuthenticationSchemeMiddleware(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();
            builder.Services.AddAuthorization();
        }

        public static void AddCorsMiddleware(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Total", policy =>
                {
                    policy.WithOrigins("https://localhost:44344")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });
        }

        public static void UseDevEnvironment(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger().RequireAuthorization();
        }
        public static void UseSecurity(this WebApplication app)
        {
            app.UseCors("Total");

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
