using MediatR;
using ProjectE.Application.DTOs.Customers;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using ProjectE.Core.Repositories;
using ProjectE.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Customers.LoginCustomer
{
    public class LoginCustomerHandler(IAuthService authService, ICustomerRepository customerRepository)
               : IRequestHandler<LoginCustomerCommand, Response<LoginCustomerDTO>>
    {
        public IAuthService _authService = authService;
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<Response<LoginCustomerDTO>> Handle(LoginCustomerCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var customer = await _customerRepository.GetCustomerByEmailAndPasswordAsync(request.Email, passwordHash);
            if (customer is null) return Response<LoginCustomerDTO>.Error("Está conta não existe");

            var login = new LoginCustomerDTO(customer.Email, _authService.GenerateJwtToken(customer.Email, customer.Role.ToString()));

            return Response<LoginCustomerDTO>.Success(login);
        }
    }
}
