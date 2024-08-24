using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Infrastructure.Mappings
{
    public class ProjectMapping : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Freelancer).WithMany(f => f.FreelanceProjects)
                .HasForeignKey(p => p.FreelancerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Customer).WithMany(c => c.OwnedProjects)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
