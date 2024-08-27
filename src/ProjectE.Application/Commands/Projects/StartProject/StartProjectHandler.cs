using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Repositories;

namespace ProjectE.Application.Commands.Projects.StartProject
{
    public class StartProjectHandler(IProjectRepository projectRepository) : IRequestHandler<StartProjectCommand, Response>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<Response> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectByIdAsync(request.Id);

            if (project is null) return Response.Error("Projeto nao existente");

            project.Start();

            await _projectRepository.UpdateProjectAsync(project);

            return Response.Success();
        }
    }
}
