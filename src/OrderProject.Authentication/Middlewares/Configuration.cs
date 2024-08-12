using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderProject.Authentication.Data;
using OrderProject.Authentication.Data.Users;
using OrderProject.Domain.Entities.Identity;
using System;

namespace OrderProject.Authentication.Middlewares
{
    public static class Configuration
    {
        public static void AddDbContextConfig(this WebApplicationBuilder builder) => builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        public static void AddIdentityEndPoints(this IServiceCollection services)
        {
            services.AddIdentityCore<UserRoles>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddApiEndpoints();
        }
        public static void AddDocumentationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n => n.FullName);
            });
        }
        public static void AddEnvConfig(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
        public static void AddSecurityConfig(this IServiceCollection services)
        {
            services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
            services.AddAuthorization();
        }
        public static void AddCorsConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Total", policy =>
                {
                    policy.WithOrigins("https://localhost:")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });
        }

        public static void UseConfigureDevEnvironment(this WebApplication app)
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
