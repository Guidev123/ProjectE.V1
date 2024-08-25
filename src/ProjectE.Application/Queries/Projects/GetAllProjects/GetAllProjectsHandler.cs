using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectE.Application.DTOs.Projects;
using ProjectE.Application.Responses;
using ProjectE.Infrastructure;

namespace ProjectE.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectsHandler(ProjectEDbContext context) : IRequestHandler<GetAllProjectsQuery, Response<List<ProjectItemDTO>>>
    {
        private readonly ProjectEDbContext _context = context;
        public async Task<Response<List<ProjectItemDTO>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Projects.AsNoTracking().Include(x => x.Customer).Include(x => x.Freelancer)
                    .Where(x => !x.IsDeleted)
                    .ToListAsync();

            var result = query.Select(ProjectItemDTO.FromEntity).ToList();

            return Response<List<ProjectItemDTO>>.Success(result);
        }
    }
}
