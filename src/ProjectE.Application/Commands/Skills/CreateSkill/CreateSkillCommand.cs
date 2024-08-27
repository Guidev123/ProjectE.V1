using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Skills.CreateSkill
{
    public class CreateSkillCommand : IRequest<Response>
    {
        public CreateSkillCommand(string description, Guid customerId)
        {
            Description = description;
            CustomerId = customerId;
        }
        public Guid CustomerId { get; private set; }
        public string Description { get; private set; }
        public Skill ToEntity()
            => new(Description, CustomerId);
    }
}
