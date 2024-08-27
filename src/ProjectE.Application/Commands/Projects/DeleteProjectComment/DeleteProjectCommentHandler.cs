using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Repositories;

namespace ProjectE.Application.Commands.Projects.DeleteProjectComment
{
    public class DeleteProjectCommentHandler(IProjectRepository projectRepository) : IRequestHandler<DeleteProjectCommentCommand, Response>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<Response> Handle(DeleteProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectCommentByIdAsync(request.Id);

            if (project is null) return Response.Error("Este comentario nao existe");

            project.SetEntityAsDeleted();
            await _projectRepository.UpdateProjectCommentAsync(project);

            return Response.Success();
        }
    }
}
