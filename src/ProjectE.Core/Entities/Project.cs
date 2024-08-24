using ProjectE.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Core.Entities
{
    public class Project : Entity
    {
        public Project(Guid customerId, Guid freelancerId, string title, string description, decimal totalPrice) : base()
        {
            CustomerId = customerId;
            FreelancerId = freelancerId;
            Title = title;
            Description = description;
            TotalPrice = totalPrice;
            ProjectStatus = EProjectStatus.Created;
            Comments = [];
        }

        public Guid CustomerId { get; private set; }
        public Guid FreelancerId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal TotalPrice { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public EProjectStatus ProjectStatus { get; private set; }
        public List<ProjectComment> Comments { get; private set; } = [];

        // EF Relation
        protected Project() { }
        public Customer Customer { get; private set; } = null!;
        public Customer Freelancer { get; private set; } = null!;

        public void Cancel()
        {
            if(ProjectStatus is EProjectStatus.InProgress || ProjectStatus is EProjectStatus.Suspended )
                ProjectStatus = EProjectStatus.Cancelled;
        }
        public void Start()
        {
            if (ProjectStatus is EProjectStatus.Created)
            {
                ProjectStatus = EProjectStatus.InProgress;
                StartedAt = DateTime.Now;
            }
        }
        public void Complete()
        {
            if (ProjectStatus is EProjectStatus.WaitingPayment || ProjectStatus is EProjectStatus.InProgress)
            {
                ProjectStatus = EProjectStatus.Completed;
                CompletedAt = DateTime.Now;
            }
        }
        public void SetAsWaitingPayment()
        {
            if (ProjectStatus is EProjectStatus.InProgress)
                ProjectStatus = EProjectStatus.WaitingPayment;
        }
        public void Update(string title, string description, decimal totalPrice)
        {
            Title = title;
            Description = description;
            TotalPrice = totalPrice;
        }
    }
}
