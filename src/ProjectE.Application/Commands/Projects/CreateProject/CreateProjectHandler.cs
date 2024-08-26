using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using ProjectE.Core.Repositories;

namespace ProjectE.Application.Commands.Projects.CreateProject
{
    public class CreateProjectHandler(IProjectRepository projectRepository) : IRequestHandler<CreateProjectCommand, Response>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<Response> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.ToEntity();

            await _projectRepository.CreateProjectAsync(project);

            return Response<Project>.Success(project);
        }
    }
}
