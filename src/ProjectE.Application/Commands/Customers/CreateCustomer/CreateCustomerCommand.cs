using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using ProjectE.Core.Enums;

namespace ProjectE.Application.Commands.Customers.CreateCustomers
{
    public class CreateCustomerCommand : IRequest<Response>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ECustomerType Role { get; set; } 
        public DateTime BirthDate { get; set; }

        public Customer ToEntity()
            => new(Name, Email, BirthDate, true, Password, Role);
    }
}
