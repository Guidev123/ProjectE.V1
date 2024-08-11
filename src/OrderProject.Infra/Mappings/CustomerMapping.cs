using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProject.Domain.Entities.Customer;
using OrderProject.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Infra.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);
            builder.Property(c => c.Name).IsRequired().HasColumnType("VARCHAR(200)");

            builder.OwnsOne(c => c.Cpf, tf =>
            {
                tf.Property(c => c.Number)
                    .IsRequired()
                    .HasMaxLength(Cpf.CpfMax)
                    .HasColumnName("Cpf")
                    .HasColumnType($"VARCHAR({Cpf.CpfMax})");
            });

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Address)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"VARCHAR({Email.EnderecoMaxLength})");
            });
            builder.OwnsOne(c => c.Phone, tf =>
            {
                tf.Property(c => c.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("PhoneNumber")
                    .HasColumnType($"VARCHAR({Phone.PhoneNumberMaxLength})");
            });

            // 1:N
            builder.HasMany(c => c.Orders).WithOne(o => o.Customer)
                  .HasForeignKey(o => o.CustomerId)
                  .IsRequired();
        }
    }
}
