using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Core.Entities
{
    public class Skill : Entity
    {
        public Skill(string description, Guid customerId) : base()
        {
            Description = description;
            CustomerId = customerId;
        }
        public Guid CustomerId { get; private set; }
        public string Description { get; private set; }

        protected Skill(){  }
        public Customer Customer { get; private set; } = null!;
    }
}
