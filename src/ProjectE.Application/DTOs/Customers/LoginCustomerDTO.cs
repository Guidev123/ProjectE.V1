using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.DTOs.Customers
{
    public class LoginCustomerDTO(string email, string token)
    {
        public string Email { get; private set; } = email;
        public string Token { get; private set; } = token;
    }
}
