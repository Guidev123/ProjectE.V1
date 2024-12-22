using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.CreateProject
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(2).MaximumLength(50)
                .WithMessage("O titulo deve conter de 2 a 50 caracters");

            RuleFor(x => x.TotalPrice).GreaterThanOrEqualTo(1000).WithMessage("O projeto deve custar no minimo $1.000");
        }
    }
}
