using MediatR;
using ProjectE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.StartProject
{
    public class StartProjectCommand : IRequest<Response>
    {
        public StartProjectCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
