using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Repositories;

namespace ProjectE.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectHandler(IProjectRepository projectRepository) : IRequestHandler<UpdateProjectCommand, Response>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<Response> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectByIdAsync(request.ProjectId);

            if (project is null) return Response.Error("Projeto nao existente");

            project.Update(request.Title, request.Description, request.TotalPrice);

            await _projectRepository.UpdateProjectAsync(project);

            return Response.Success();
        }
    }
}
