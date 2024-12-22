using ProjectE.Core.Entities;
namespace ProjectE.Core.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
    Task<Project?> GetDetailsByIdAsync(Guid id);
    Task<Project?> GetByIdAsync(Guid id);
    Task<ProjectComment?> GetCommentByIdAsync(Guid id);
    Task<Project> CreateAsync(Project project);
    Task<bool> ExistsAsync(Guid id);
    Task UpdateAsync(Project project);
    Task UpdateCommentAsync(ProjectComment comment);
    Task CreateCommentAsync(ProjectComment comment);
}
