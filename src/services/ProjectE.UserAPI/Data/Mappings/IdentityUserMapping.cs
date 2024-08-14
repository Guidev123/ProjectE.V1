using HealthLife.UserAPI.Models;
using HealthLife.UserAPI.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthLife.UserAPI.Data.Mappings
{
    public class IdentityUserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.NormalizedUserName).IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(180);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(180);
            builder.Property(u => u.UserName).HasMaxLength(180);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(180);
            builder.Property(u => u.PhoneNumber).HasMaxLength(20);
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken().HasMaxLength(180);
            builder.Property(u => u.SecurityStamp).IsConcurrencyToken().HasMaxLength(180);
            builder.Property(u => u.PasswordHash).HasMaxLength(180);

            builder.OwnsOne(c => c.Cpf, tf =>
            {
                tf.Property(c => c.Number)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("Cpf")
                    .HasColumnType("VARCHAR");
            });


            builder.HasMany<IdentityUserClaim<long>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
            builder.HasMany<IdentityUserLogin<long>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            builder.HasMany<IdentityUserToken<long>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            builder.HasMany<IdentityUserRole<long>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
        }
    }
}
