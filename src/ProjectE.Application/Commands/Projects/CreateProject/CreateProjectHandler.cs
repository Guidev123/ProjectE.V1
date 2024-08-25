using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using ProjectE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.CreateProject
{
    public class CreateProjectHandler(ProjectEDbContext context) : IRequestHandler<CreateProjectCommand, Response>
    {
        private readonly ProjectEDbContext _context = context;

        public async Task<Response> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.ToEntity();

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return Response<Project>.Success(project);
        }
    }
}
