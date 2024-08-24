using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Core.Entities
{
    public class Skill : Entity
    {
        public Skill(string description) : base()
        {
            Description = description;
        }
        public string? Description { get; private set; }
        public List<CustomerSkill>? CustomerSkills { get; private set; }

    }
}
