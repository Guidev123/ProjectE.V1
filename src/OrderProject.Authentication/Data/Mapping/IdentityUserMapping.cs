using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProject.Authentication.Data.Users;
using OrderProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Authentication.Data.Mapping
{
    public class IdentityUserMapping : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.ToTable("IdentityUser");
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.NormalizedUserName).IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).IsUnique();

            builder.Property(u => u.Email).HasMaxLength(180);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(180);
            builder.Property(u => u.UserName).HasMaxLength(180);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(180);
            builder.Property(u => u.PhoneNumber).HasMaxLength(20);
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            builder.HasMany<IdentityUserClaim<Guid>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
            builder.HasMany<IdentityUserLogin<Guid>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            builder.HasMany<IdentityUserToken<Guid>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            builder.HasMany<IdentityUserRole<Guid>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
        }
    }
}
