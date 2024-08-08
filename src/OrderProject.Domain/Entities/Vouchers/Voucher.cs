using OrderProject.Domain.Entities;
using OrderProject.Domain.Entities.Vouchers.Specs;
using OrderProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Domain.Entities.Vouchers
{
    public class Voucher : Entity
    {
        public string? Code { get; private set; }
        public decimal? Percentage { get; private set; }
        public decimal? DiscountAmount { get; private set; }
        public int Quantity { get; private set; }
        public EDiscountType DiscountType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UsedAt { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsUsed { get; private set; }

        public bool IsValidForUse()
        {
            var spec = new ActiveVoucherSpecification()
                .And(new VoucherQuantitySpecification())
                .And(new VoucherDateSpecification());

            return spec.IsSatisfiedBy(this);
        }

        public void MarkAsUsed()
        {
            IsActive = false;
            IsUsed = true;
            Quantity = 0;
        }

        public void DebitQuantity()
        {
            Quantity -= 1;
            if (Quantity >= 1) return;

            MarkAsUsed();
        }

    }
}
