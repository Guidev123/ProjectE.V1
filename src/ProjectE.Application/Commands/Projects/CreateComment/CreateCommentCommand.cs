using MediatR;
using ProjectE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.CreateComment
{
    public class CreateCommentCommand : IRequest<Response>
    {
        public Guid CustomerId { get; set; }
        public Guid ProjectId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
