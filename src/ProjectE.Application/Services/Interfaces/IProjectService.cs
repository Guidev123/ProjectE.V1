using ProjectE.Application.DTOs;
using ProjectE.Application.DTOs.Projects;
using ProjectE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Services.Interfaces
{
    public interface IProjectService
    {
        Task<Response<List<ProjectItemDTO>>> GetAllProjectsAsync();
        Task<Response<ProjectDTO>> GetProjectByIdAsync(Guid id);
        Task<Response<Project>> CreateProjectAsync(CreateProjectDTO model);
        Task<Response> DeleteProjectAsync(Guid id);
        Task<Response> UpdateProjectAsync(UpdateProjectDTO model);
        Task<Response> CreateProjectCommentAsync(Guid id, CreateProjectCommentDTO model);
        Task<Response> StartProjectAsync(Guid id);
        Task<Response> CompleteProjectAsync(Guid id);

    }
}
