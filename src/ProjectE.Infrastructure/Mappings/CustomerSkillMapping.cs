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
    public class CustomerSkillMapping : IEntityTypeConfiguration<CustomerSkill>
    {
        public void Configure(EntityTypeBuilder<CustomerSkill> builder)
        {
            builder.ToTable("CustomerSkills");

            builder.HasKey(us => us.Id);
            builder.HasOne(u => u.Skill)
                .WithMany(u => u.CustomerSkills)
                .HasForeignKey(s => s.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
