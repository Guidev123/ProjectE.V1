using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using ProjectE.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Skills.CreateSkill
{
    public class CreateSkillHandler(ICustomerRepository customerRepository) : IRequestHandler<CreateSkillCommand, Response>
    {
        public ICustomerRepository _customerRepository = customerRepository;

        public async Task<Response> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = request.ToEntity();
            var createSkill = await _customerRepository.CreateCustomerSkillAsync(skill);

            return Response<Skill>.Success(createSkill);
        }
    }
}
