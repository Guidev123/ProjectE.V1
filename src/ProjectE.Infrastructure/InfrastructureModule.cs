using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectE.Application.Services;
using ProjectE.Core.Repositories;
using ProjectE.Infrastructure.Persistence;
using ProjectE.Infrastructure.Persistence.Repositories;

namespace ProjectE.Infrastructure
{
    public static class InfrastructureModule
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddData(configuration);
            services.AddRepositories();
        }
        private static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            services.AddDbContext<ProjectEDbContext>(o => o.UseSqlServer(connectionString));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}
