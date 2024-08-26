using FluentValidation;
using ProjectE.Application.Commands.Customers.CreateCustomers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Validators.Projects
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {

            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.Email).EmailAddress().WithMessage("Email invalido");

            RuleFor(c => c.BirthDate).Must(d => d <= DateTime.Now.AddYears(-16))
                .WithMessage("Para criar a conta deve ter mais de 16 anos");
        }
    }
}
