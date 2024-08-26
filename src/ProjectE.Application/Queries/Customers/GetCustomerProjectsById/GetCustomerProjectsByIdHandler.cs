using MediatR;
using ProjectE.Application.DTOs.Customers;
using ProjectE.Application.DTOs.Projects;
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
               : IRequestHandler<GetCustomerProjectsByIdQuery, Response<CustomerDTO>>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<Response<CustomerDTO>> Handle(GetCustomerProjectsByIdQuery request, CancellationToken cancellationToken)
        {
            await _customerRepository.CustomerExistsAsync(request.Id);

            var customerProjects = await _customerRepository.GetCustomerProjectsByIdAsync(request.Id);

            if (customerProjects is null) return Response<CustomerDTO>.Error("Cliente nao possui projetos");

            var result = CustomerDTO.FromEntity(customerProjects);

            return Response<CustomerDTO>.Success(result);
        }
    }
}
