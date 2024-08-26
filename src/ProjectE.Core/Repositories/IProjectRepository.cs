using ProjectE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project?> GetProjectDetailsByIdAsync(Guid id);
        Task<Project?> GetProjectByIdAsync(Guid id);
        Task<ProjectComment?> GetProjectCommentByIdAsync(Guid id);
        Task<Project> CreateProjectAsync(Project project);
        Task<bool> ProjectExistsAsync(Guid id);
        Task UpdateProjectAsync(Project project);
        Task UpdateProjectCommentAsync(ProjectComment comment);
        Task CreateProjectCommentAsync(ProjectComment comment);
    }
}
