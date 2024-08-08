using OrderProject.Business.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Business.Entities.Vouchers.Specs
{
    public class VoucherSpec : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression()
        {
            return discount => discount.ExpirationDate >= DateTime.Now;
        }
    }
}
