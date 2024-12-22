using Microsoft.EntityFrameworkCore;
using ProjectE.Core.Entities;

namespace ProjectE.Infrastructure.Persistence;

public class ProjectEDbContext : DbContext
{
    public ProjectEDbContext(DbContextOptions<ProjectEDbContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<ProjectComment> ProjectComments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        foreach (var property in builder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(180)");

        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e =>
                        e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.Cascade;

        builder.ApplyConfigurationsFromAssembly(typeof(ProjectEDbContext).Assembly);
    }
}
