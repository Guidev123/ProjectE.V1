using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using ProjectE.Core.Repositories;

namespace ProjectE.Application.Commands.Projects.CreateComment
{
    public class CreateCommentHandler(IProjectRepository projectRepository) : IRequestHandler<CreateCommentCommand, Response>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<Response> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var exists = await _projectRepository.ProjectExistsAsync(request.ProjectId);

            if (!exists) return Response.Error("Projeto não existente");

            var comment = new ProjectComment(request.Content, request.ProjectId, request.CustomerId);

            await _projectRepository.CreateProjectCommentAsync(comment);

            return Response.Success();
        }
    }
}
