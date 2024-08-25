using Microsoft.Extensions.DependencyInjection;
using ProjectE.Application.Commands.Projects.CreateComment;
using ProjectE.Application.Commands.Projects.CreateProject;

namespace ProjectE.Application.Configuration
{
    public static class ApplicationModule
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddHandlers();
        }

        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CreateProjectCommand>());
        }
    }
}
