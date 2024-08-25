using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectE.Application.Responses;
using ProjectE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.CompleteProject
{
    public class CompleteProjectHandler(ProjectEDbContext context) : IRequestHandler<CompleteProjectCommand, Response>
    {
        private readonly ProjectEDbContext _context = context;

        public async Task<Response> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project is null) return Response.Error("Projeto nao existente");

            project.Complete();
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return Response.Success();
        }
    }
}
