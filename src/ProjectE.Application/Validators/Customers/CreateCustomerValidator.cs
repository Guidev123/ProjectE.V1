using FluentValidation;
using ProjectE.Application.Commands.Customers.CreateCustomers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Validators.Customers
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {

            RuleFor(c => c.Name).NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("É necessário um endereço de e-mail válido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres.")
                .Matches(@"[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches(@"[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches(@"\d").WithMessage("A senha deve conter pelo menos um dígito.")
                .Matches(@"[\W_]").WithMessage("A senha deve conter pelo menos um caractere especial.");

            RuleFor(c => c.BirthDate).Must(d => d <= DateTime.Now.AddYears(-16))
                .WithMessage("Para criar a conta deve ter mais de 16 anos");
        }
    }
}
