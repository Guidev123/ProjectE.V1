using MediatR;
using ProjectE.Application.DTOs.Skills;
using ProjectE.Application.Responses;
using ProjectE.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Queries.Customers.GetCustomerSkillById
{
    public class GetCustomerSkillByIdHandler(ICustomerRepository customerRepository) : IRequestHandler<GetCustomerSkillByIdQuery, Response>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<Response> Handle(GetCustomerSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var customerSkills = await _customerRepository.GetCustomerSkillByIdAsync(request.Id);

            var result = customerSkills
        }
    }
}
