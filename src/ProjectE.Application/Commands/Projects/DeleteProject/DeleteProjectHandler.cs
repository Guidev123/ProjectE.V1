using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.DeleteProject
{
    public class DeleteProjectHandler(IProjectRepository projectRepository) : IRequestHandler<DeleteProjectCommand, Response>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<Response> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectByIdAsync(request.Id);

            if (project is null) return Response.Error("Projeto nao existe");

            project.SetEntityAsDeleted();
            await _projectRepository.UpdateProjectAsync(project);

            return Response.Success();
        }
    }
}
