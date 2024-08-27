using MediatR;
using ProjectE.Application.DTOs.Projects;
using ProjectE.Application.Responses;
using ProjectE.Core.Repositories;

namespace ProjectE.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectsHandler(IProjectRepository projectRepository) : IRequestHandler<GetAllProjectsQuery, Response<List<ProjectItemDTO>>>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;
        public async Task<Response<List<ProjectItemDTO>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllProjectsAsync();

            var result = projects.Select(ProjectItemDTO.FromEntity).ToList();

            return Response<List<ProjectItemDTO>>.Success(result);
        }
    }
}
