using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using ProjectE.Core.Repositories;
using ProjectE.Core.Services;

namespace ProjectE.Application.Commands.Customers.CreateCustomers
{
    public class CreateCustomerHandler(ICustomerRepository customerRespository, IAuthService authService) : IRequestHandler<CreateCustomerCommand, Response>
    {
        private readonly ICustomerRepository _customerRepository = customerRespository;
        private readonly IAuthService _authService = authService;

        public async Task<Response> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            request.Password = _authService.ComputeSha256Hash(request.Password);
            var customer = request.ToEntity();

            await _customerRepository.CreateCustomerAsync(customer);

            return Response<Customer>.Success(customer);
        }
    }
}
