using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectE.Application.Responses;
using ProjectE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectHandler(ProjectEDbContext context) : IRequestHandler<UpdateProjectCommand, Response>
    {
        private readonly ProjectEDbContext _context = context;

        public async Task<Response> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId);

            if (project is null) return Response.Error("Projeto nao existente");

            project.Update(request.Title, request.Description, request.TotalPrice);

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return Response.Success();
        }
    }
}
