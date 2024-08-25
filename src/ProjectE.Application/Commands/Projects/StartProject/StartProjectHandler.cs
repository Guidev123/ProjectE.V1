using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectE.Application.Responses;
using ProjectE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.StartProject
{
    public class StartProjectHandler(ProjectEDbContext context) : IRequestHandler<StartProjectCommand, Response>
    {
        private readonly ProjectEDbContext _context = context;

        public async Task<Response> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project is null) return Response.Error("Projeto nao existente");

            project.Start();
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return Response.Success();
        }
    }
}
