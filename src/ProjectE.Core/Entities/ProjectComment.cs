using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Core.Entities
{
    public class ProjectComment : Entity
    {
        public ProjectComment(string content, Guid projectId, Guid customerId) : base()
        {
            Content = content;
            ProjectId = projectId;
            CustomerId = customerId;
        }

        public Guid ProjectId { get; private set; }
        public Guid CustomerId { get; private set; }
        public string? Content { get; private set; }

        // EF Relation
        protected ProjectComment() { }
        public Project Project { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
    }
}
