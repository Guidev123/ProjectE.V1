using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectE.Application.Commands.Customers.CreateCustomer;
using ProjectE.Application.Commands.Projects.CreateComment;
using ProjectE.Application.Commands.Projects.CreateProject;
using ProjectE.Application.Responses;

namespace ProjectE.Application
{
    public static class ApplicationModule
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddHandlers();
            services.AddValidation();
        }

        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CreateProjectCommand>());
        }


        public static void AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<CreateCustomerValidator>();
        }
    }
}
