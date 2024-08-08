using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Business.Enums
{
    public enum EStatusOrder
    {
        Authorized = 1,
        Paid = 2,
        NotAuthorized = 3,
        Delivered = 4,
        Canceled = 5
    }
}
