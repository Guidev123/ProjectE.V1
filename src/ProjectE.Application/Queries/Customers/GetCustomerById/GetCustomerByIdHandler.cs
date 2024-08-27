using MediatR;
using ProjectE.Application.DTOs.Customers;
using ProjectE.Application.DTOs.Skills;
using ProjectE.Application.Responses;
using ProjectE.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Queries.Customers.GetCustomerById
{
    public class GetCustomerByIdHandler(ICustomerRepository customerRepository) : IRequestHandler<GetCustomerByIdQuery, Response>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        public async Task<Response> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.Id);

            if (customer is null) return Response.Error("Este cliente nao existe");

            var result = CustomerDTO.FromEntity(customer);

            return Response<CustomerDTO>.Success(result);
        }
    }
}
