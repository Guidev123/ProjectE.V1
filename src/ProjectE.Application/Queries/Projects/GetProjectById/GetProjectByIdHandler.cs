using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectE.Application.DTOs.Projects;
using ProjectE.Application.Responses;
using ProjectE.Infrastructure;

namespace ProjectE.Application.Queries.Projects.GetProjectById
{
    public class GetProjectByIdHandler(ProjectEDbContext context) : IRequestHandler<GetProjectByIdQuery, Response<ProjectDTO>>
    {
        private readonly ProjectEDbContext _context = context;

        public async Task<Response<ProjectDTO>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Projects.Include(x => x.Customer).Include(x => x.Freelancer)
                        .Include(x => x.Comments).SingleOrDefaultAsync(x => x.Id == request.Id);

            if (query is null) return Response<ProjectDTO>.Error("Projeto nao existente");

            var result = ProjectDTO.FromEntity(query);

            return Response<ProjectDTO>.Success(result);
        }
    }
}
