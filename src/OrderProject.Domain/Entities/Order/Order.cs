using OrderProject.Domain.Entities;
using OrderProject.Domain.Entities.Vouchers;
using OrderProject.Domain.Enums;
using OrderProject.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Domain.Entities.Order
{
    public class Order : Entity
    {
        public Order(Guid customerId, decimal totalPrice, List<OrderItem> orderItems, bool voucherUsed = false,
            decimal discount = 0, Guid? voucherId = null)
        {
            CustomerId = customerId;
            TotalPrice = totalPrice;
            _orderItems = orderItems;
            Discount = discount;
            VoucherUsed = voucherUsed;
            VoucherId = voucherId;
        }

        public int Code { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUsed { get; private set; }
        public decimal Discount { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalPrice { get; private set; }
        public EStatusOrder StatusOrder { get; private set; }
        private readonly List<OrderItem>? _orderItems;
        public IReadOnlyCollection<OrderItem>? OrderItens => _orderItems;

        public void AuthorizedOrder() => StatusOrder = EStatusOrder.Authorized;
        public void NotAuthorizedOrder() => StatusOrder = EStatusOrder.NotAuthorized;
        public void PayOrder() => StatusOrder = EStatusOrder.Paid;
        public void GetAddress(Address address) => Address = address;
        public void ApplyVoucher(Voucher voucher)
        {
            VoucherUsed = true;
            VoucherId = voucher.Id;
            Voucher = voucher;
        }
        public void CalculateOrderValue()
        {
            if (OrderItens is null) throw new DomainException();
            TotalPrice = OrderItens.Sum(item => item.CalculateValue());
            CalculateTotalDiscountValue();
        }

        private void CalculateTotalDiscountValue()
        {
            if (!VoucherUsed) return;

            decimal discount = 0;
            var value = TotalPrice;

            if (Voucher?.DiscountType == EDiscountType.Percentage)
            {
                if (Voucher.Percentage.HasValue)
                {
                    discount = value * Voucher.Percentage.Value / 100;
                    value -= discount;
                }
            }
            else
            {
                if (Voucher is null) throw new DomainException();
                if (Voucher.DiscountAmount.HasValue)
                {
                    discount = Voucher.DiscountAmount.Value;
                    value -= discount;
                }
            }

            TotalPrice = value < 0 ? 0 : value;
            Discount = discount;
        }

        //EF relation
        protected Order() { }
        public Voucher? Voucher { get; private set; }
        public Address? Address { get; private set; }

    }
}
