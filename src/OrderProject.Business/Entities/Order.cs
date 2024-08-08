using OrderProject.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Business.Entities
{
    public class Order : Entity
    {
        public Order(Guid customerId, decimal totalPrice, List<OrderItem> orderItems, bool voucherUsed = false,
            decimal discount = 0, Guid? voucherId = null)
        {
            CustomerId = customerId;
            TotalPrice = totalPrice;

        }
        //EF ctor
        protected Order() { }

        public int Code { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUsed { get; private set; }
        public decimal Discount { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalPrice { get; private set; }
        public EStatusOrder StatusOrder { get; set; }
        private readonly List<OrderItem>? _orderItems;
        public IReadOnlyCollection<OrderItem>? OrderItems => _orderItems;
    }
}
