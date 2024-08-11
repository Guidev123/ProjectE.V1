using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProject.Domain.Entities.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Infra.Mappings
{
    public class VoucherMapping : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("Vouchers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired().HasColumnType("VARCHAR").HasMaxLength(256);
            builder.Property(x => x.Percentage).HasColumnType("MONEY").IsRequired(false);
            builder.Property(x => x.DiscountAmount).HasColumnType("MONEY").IsRequired(false);

        }
    }
}
