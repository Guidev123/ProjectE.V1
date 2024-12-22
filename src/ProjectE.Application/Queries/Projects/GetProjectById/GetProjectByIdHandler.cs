using MediatR;
using ProjectE.Application.DTOs.Projects;
using ProjectE.Application.Responses;
using ProjectE.Core.Repositories;

namespace ProjectE.Application.Queries.Projects.GetProjectById
{
    public class GetProjectByIdHandler(IProjectRepository projectRepository) : IRequestHandler<GetProjectByIdQuery, Response<ProjectDTO>>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<Response<ProjectDTO>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetDetailsByIdAsync(request.Id);

            if (project is null) return Response<ProjectDTO>.Error("Projeto nao existente");

            var result = ProjectDTO.FromEntity(project);

            return Response<ProjectDTO>.Success(result);
        }
    }
}
