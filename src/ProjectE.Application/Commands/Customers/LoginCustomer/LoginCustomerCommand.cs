using MediatR;
using ProjectE.Application.DTOs.Customers;
using ProjectE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Customers.LoginCustomer
{
    public class LoginCustomerCommand : IRequest<Response<LoginCustomerDTO>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
