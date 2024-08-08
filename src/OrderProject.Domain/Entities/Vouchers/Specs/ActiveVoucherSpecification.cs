using OrderProject.Domain.Entities.Vouchers;
using OrderProject.Domain.Specifications;
using System.Linq.Expressions;

namespace OrderProject.Domain.Entities.Vouchers.Specs
{
    public class ActiveVoucherSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression()
        {
            return discount => discount.IsActive && !discount.IsUsed;
        }
    }

}
