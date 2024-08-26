using MediatR;
using ProjectE.Application.DTOs.Customers;
using ProjectE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Queries.Customers.GetCustomerProjectsById
{
    public class GetCustomerProjectsByIdQuery : IRequest<Response<CustomerDTO>>
    {
        public GetCustomerProjectsByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
