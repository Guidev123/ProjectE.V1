using Microsoft.Extensions.DependencyInjection;
using ProjectE.Application.Services;
using ProjectE.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Configuration
{
    public static class ApplicationModule
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddServices(services);
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProjectService, ProjectService>();
        }
    }
}
