using MediatR;
using ProjectE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Queries.Skills.GetSkillsByCustomerId
{
    public class GetSkillsByCustomerIdCommand : IRequest<Response>
    {
        public GetSkillsByCustomerIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
