﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectE.Application.Responses;
using ProjectE.Core.Repositories;
using ProjectE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.CompleteProject
{
    public class CompleteProjectHandler(IProjectRepository projectRepository) : IRequestHandler<CompleteProjectCommand, Response>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<Response> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectByIdAsync(request.Id);

            if (project is null) return Response.Error("Projeto nao existente");

            project.Complete();
            
            await _projectRepository.UpdateProjectAsync(project);

            return Response.Success();
        }
    }
}
