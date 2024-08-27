using MediatR;
using ProjectE.Application.DTOs.Skills;
using ProjectE.Application.Responses;
using ProjectE.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Queries.Skills.GetSkillsByCustomerId
{
    public class GetSkillsByCustomerIdHandler(ICustomerRepository customerRepository) : IRequestHandler<GetSkillsByCustomerIdCommand, Response>
    {
        public ICustomerRepository _customerRepository = customerRepository;

        public async Task<Response> Handle(GetSkillsByCustomerIdCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerSkillsByIdAsync(request.Id);

            if (customer is null) return Response.Error("Este cliente nao existe");

            var result = CustomerSkillsDTO.FromEntity(customer);

            return Response<CustomerSkillsDTO>.Success(result);

        }
    }
}
