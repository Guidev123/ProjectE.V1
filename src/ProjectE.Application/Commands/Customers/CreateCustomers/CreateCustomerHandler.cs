using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using ProjectE.Core.Repositories;

namespace ProjectE.Application.Commands.Customers.CreateCustomers
{
    public class CreateCustomerHandler(ICustomerRepository customerRespository) : IRequestHandler<CreateCustomerCommand, Response>
    {
        private readonly ICustomerRepository _customerRepository = customerRespository;
        public async Task<Response> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = request.ToEntity();

            await _customerRepository.CreateCustomerAsync(customer);

            return Response<Customer>.Success(customer);
        }
    }
}
