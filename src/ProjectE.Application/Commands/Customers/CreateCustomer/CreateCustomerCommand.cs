using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using ProjectE.Core.Services;
using System.Text.Json.Serialization;

namespace ProjectE.Application.Commands.Customers.CreateCustomers
{
    public class CreateCustomerCommand(IAuthService service) : IRequest<Response>
    {
        [JsonIgnore]
        public IAuthService _service = service;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public Customer ToEntity()
            => new(Name, Email, BirthDate, true, _service.ComputeSha256Hash(Password), Role);
    }
}
