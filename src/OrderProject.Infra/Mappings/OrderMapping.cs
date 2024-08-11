using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProject.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Infra.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).HasColumnType("VARCHAR").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Discount).HasColumnType("MONEY");
            builder.Property(x => x.TotalPrice).HasColumnType("MONEY");
            builder.OwnsOne(p => p.Address, e =>
            {
                e.Property(pe => pe.Street)
                    .HasColumnName("Street");

                e.Property(pe => pe.Number)
                    .HasColumnName("Number");

                e.Property(pe => pe.Complement)
                    .HasColumnName("Complement");

                e.Property(pe => pe.Neighborhood)
                    .HasColumnName("Neighborhood");

                e.Property(pe => pe.PostalCode)
                    .HasColumnName("PostalCode");

                e.Property(pe => pe.City)
                    .HasColumnName("City");

                e.Property(pe => pe.State)
                    .HasColumnName("State");
            });
        }
    }
}
