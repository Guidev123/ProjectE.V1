    using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ProjectE.Core.Entities;
using ProjectE.Core.Repositories;


namespace ProjectE.Infrastructure.Repositories
{
    public class ProjectRepository(ProjectEDbContext context) : IProjectRepository
    {
        private readonly ProjectEDbContext _context = context;

        public async Task<Project> CreateProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task CreateProjectCommentAsync(ProjectComment comment)
        {
            await _context.ProjectComments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            var query = await _context.Projects.AsNoTracking().Include(x => x.Customer).Include(x => x.Freelancer)
                    .Where(x => !x.IsDeleted)
                    .ToListAsync();

            return query;
        }

        public async Task<Project?> GetProjectByIdAsync(Guid id)
        {
            var query = await _context.Projects.SingleOrDefaultAsync(x => x.Id == id);

            return query;
        }

        public async Task<ProjectComment?> GetProjectCommentByIdAsync(Guid id)
        {
            var query = await _context.ProjectComments.SingleOrDefaultAsync(x => x.Id == id);

            return query;
        }

        public async Task<Project?> GetProjectDetailsByIdAsync(Guid id)
        {
            var query = await _context.Projects.Include(x => x.Customer).Include(x => x.Freelancer)
            .Include(x => x.Comments).SingleOrDefaultAsync(x => x.Id == id);

            return query;
        }

        public async Task<bool> ProjectExistsAsync(Guid id)
            => await _context.Projects.AnyAsync(project => project.Id == id);
        
        public async Task UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectCommentAsync(ProjectComment comment)
        {
            _context.ProjectComments.Update(comment);
            await _context.SaveChangesAsync();
        }
    }
}
