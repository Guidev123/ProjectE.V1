using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Queries.Customers.GetCustomerProjectsById
{
    public class GetCustomerProjectsByIdHandler(ICustomerRepository customerRepository)
               : IRequestHandler<GetCustomerProjectsByIdQuery, Response>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<Response> Handle(GetCustomerProjectsByIdQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
