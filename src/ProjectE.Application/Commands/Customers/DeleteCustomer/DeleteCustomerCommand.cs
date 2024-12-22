using MediatR;
using ProjectE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Response>
    {
        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
