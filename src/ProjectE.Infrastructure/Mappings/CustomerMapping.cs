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
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Skills)
                .WithOne(us => us.Customer)
                .HasForeignKey(us => us.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
