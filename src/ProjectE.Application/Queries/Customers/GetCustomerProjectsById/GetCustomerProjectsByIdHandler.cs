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
               : IRequestHandler<GetCustomerProjectsByIdQuery, Response<CustomerProjectsDTO>>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<Response<CustomerProjectsDTO>> Handle(GetCustomerProjectsByIdQuery request, CancellationToken cancellationToken)
        {
            var customerProjects = await _customerRepository.GetProjectsByIdAsync(request.Id);

            if (customerProjects is null) return Response<CustomerProjectsDTO>.Error("Cliente nao possui projetos");

            var result = CustomerProjectsDTO.FromEntity(customerProjects);

            return Response<CustomerProjectsDTO>.Success(result);
        }
    }
}
