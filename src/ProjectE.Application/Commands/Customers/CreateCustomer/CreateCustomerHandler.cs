using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Application.Services;
using ProjectE.Core.Entities;
using ProjectE.Core.Repositories;

namespace ProjectE.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerHandler(ICustomerRepository customerRespository, IAuthService authService) : IRequestHandler<CreateCustomerCommand, Response>
    {
        private readonly ICustomerRepository _customerRepository = customerRespository;
        private readonly IAuthService _authService = authService;

        public async Task<Response> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            request.Password = _authService.ComputeSha256Hash(request.Password);
            var customer = request.ToEntity();

            var customerExists = await _customerRepository.ExistsAsync(customer);
            if (customerExists) return Response<Customer>.Error("Já existe um usuario com este email");

            return Response<Customer>.Success(await _customerRepository.CreateAsync(customer));
        }
    }
}
