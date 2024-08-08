using OrderProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Domain.Entities.Order
{
    public class OrderItem : Entity
    {
        public OrderItem(Guid productId, string productName, int quantity, decimal unitaryValue, string productImage)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitaryValue = unitaryValue;
            ProductImage = productImage;
        }
        public Guid CustomerId { get; private set; }
        public Guid ProductId { get; private set; }
        public string? ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitaryValue { get; private set; }
        public string? ProductImage { get; set; }

        internal decimal CalculateValue() => Quantity * UnitaryValue;

        //EF rel
        public Order Order { get; set; } = null!;
        protected OrderItem() { }
    }
}
