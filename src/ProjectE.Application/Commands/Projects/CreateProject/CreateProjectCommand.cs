using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.CreateProject
{
    public class CreateProjectCommand : IRequest<Response>
    {
        public Guid CustomerId { get; set; }
        public Guid FreelancerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }

        public Project ToEntity()
            => new(CustomerId, FreelancerId, Title, Description, TotalPrice);
    }
}
