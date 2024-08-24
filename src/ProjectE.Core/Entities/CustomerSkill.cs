using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Core.Entities
{
    public class CustomerSkill : Entity
    {
        public CustomerSkill(Guid customerId, Guid skillId) : base()
        {
            CustomerId = customerId;
            SkillId = skillId;
        }

        public Guid CustomerId { get; private set; }
        public Guid SkillId { get; private set; }

        // EF Relation
        protected CustomerSkill() { }
        public Customer? Customer { get; private set; }
        public Skill? Skill { get; private set; }
    }
}
