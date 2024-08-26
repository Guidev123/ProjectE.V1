using MediatR;
using ProjectE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.DeleteProjectComment
{
    public class DeleteProjectCommentCommand : IRequest<Response>
    {
        public DeleteProjectCommentCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
