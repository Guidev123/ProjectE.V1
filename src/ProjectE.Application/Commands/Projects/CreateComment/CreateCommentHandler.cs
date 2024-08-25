using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using ProjectE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.CreateComment
{
    public class CreateCommentHandler(ProjectEDbContext context) : IRequestHandler<CreateCommentCommand, Response>
    {
        private readonly ProjectEDbContext _context = context;

        public async Task<Response> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(x => x.Id == request.ProjectId);

            if (project is null) return Response.Error("Projeto não existente");

            var comment = new ProjectComment(request.Content, request.ProjectId, request.CustomerId);

            await _context.ProjectComments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return Response.Success();
        }
    }
}
