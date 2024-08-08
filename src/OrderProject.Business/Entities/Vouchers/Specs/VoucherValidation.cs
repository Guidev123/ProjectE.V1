using OrderProject.Business.Specifications.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Business.Entities.Vouchers.Specs
{
    public class VoucherValidation : SpecValidator<Voucher>
    {
        public VoucherValidation()
        {
            var dateSpec = new VoucherDateSpecification();
            var quantitySpec = new VoucherQuantitySpecification();
            var activeSpec = new ActiveVoucherSpecification();

            Add("dateSpec", new Rule<Voucher>(dateSpec, "This voucher is expired"));
            Add("quantitySpec", new Rule<Voucher>(quantitySpec, "This voucher has already been used"));
            Add("activeSpec", new Rule<Voucher>(activeSpec, "This voucher is not active"));
        }

    }
}
