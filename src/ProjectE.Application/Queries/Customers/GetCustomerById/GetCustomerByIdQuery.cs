using MediatR;
using ProjectE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Queries.Customers.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Response>
    {
        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
