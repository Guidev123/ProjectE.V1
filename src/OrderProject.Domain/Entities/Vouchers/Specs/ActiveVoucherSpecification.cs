using OrderProject.Business.Specifications;
using System.Linq.Expressions;

namespace OrderProject.Business.Entities.Vouchers.Specs
{
    public class ActiveVoucherSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression()
        {
            return discount => discount.IsActive && !discount.IsUsed;
        }
    }

}
