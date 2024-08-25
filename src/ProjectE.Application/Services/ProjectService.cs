using Microsoft.EntityFrameworkCore;
using ProjectE.Application.DTOs;
using ProjectE.Application.DTOs.Projects;
using ProjectE.Application.Services.Interfaces;
using ProjectE.Core.Entities;
using ProjectE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Services
{
    public class ProjectService(ProjectEDbContext context) : IProjectService
    {
        private readonly ProjectEDbContext _context = context;

        public async Task<Response<List<ProjectItemDTO>>> GetAllProjectsAsync()
        {
            var projects = await _context.Projects.AsNoTracking().Include(x => x.Customer).Include(x => x.Freelancer)
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            var model = projects.Select(ProjectItemDTO.FromEntity).ToList();

            return Response<List<ProjectItemDTO>>.Success(model);
        }

        public async Task<Response<ProjectDTO>> GetProjectByIdAsync(Guid id)
        {
            var project = await _context.Projects.Include(x => x.Customer).Include(x => x.Freelancer)
                .Include(x => x.Comments).SingleOrDefaultAsync(x => x.Id == id);

            if (project is null) return Response<ProjectDTO>.Error("Projeto nao existente");

            var model = ProjectDTO.FromEntity(project);

            return Response<ProjectDTO>.Success(model);
        }
        public async Task<Response> UpdateProjectAsync(UpdateProjectDTO model)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == model.ProjectId);

            if (project is null) return Response.Error("Projeto nao existente");

            project.Update(model.Title, model.Description, model.TotalPrice);
            
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return Response.Success();
        }
        public async Task<Response> CompleteProjectAsync(Guid id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);

            if (project is null) return Response.Error("Projeto nao existente");

            project.Complete();
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return Response.Success();
        }

        public async Task<Response<Project>> CreateProjectAsync(CreateProjectDTO model)
        {
            var project = model.ToEntity();

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return Response<Project>.Success(project);
        }

        public async Task<Response> CreateProjectCommentAsync(Guid projectId, CreateProjectCommentDTO model)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(x => x.Id == projectId);

            if (project is null) return Response.Error("Projeto não existente");

            var comment = new ProjectComment(model.Content, projectId, model.CustomerId);

            _context.ProjectComments.Add(comment);
            await _context.SaveChangesAsync();

            return Response.Success();
        }


        public async Task<Response> DeleteProjectAsync(Guid id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);

            if (project is null) return Response.Error("Projeto nao existente");

            project.SetEntityAsDeleted();
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return Response.Success();
        }
        public async Task<Response> StartProjectAsync(Guid id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);

            if (project is null) return Response.Error("Projeto nao existente");

            project.Start();
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return Response.Success();
        }

    }
}
