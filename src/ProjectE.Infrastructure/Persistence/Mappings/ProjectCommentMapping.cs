using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Infrastructure.Persistence.Mappings
{
    public class ProjectCommentMapping : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder.ToTable("ProjectComments");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Customer)
                .WithMany(u => u.ProjectComments)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
