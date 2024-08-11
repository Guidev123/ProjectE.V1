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
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItens");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductName).IsRequired().HasColumnType("VARCHAR").HasMaxLength(256);
            builder.Property(x => x.ProductImage).IsRequired().HasColumnType("VARCHAR").HasMaxLength(256);
            builder.Property(x => x.UnitaryValue).HasColumnType("MONEY");

            // 1:N
            builder.HasOne(x => x.Order).WithMany(x => x.OrderItens);

        }
    }
}
