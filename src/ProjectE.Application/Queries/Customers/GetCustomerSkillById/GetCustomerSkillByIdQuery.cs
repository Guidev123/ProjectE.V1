using MediatR;
using ProjectE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Queries.Customers.GetCustomerSkillById
{
    public class GetCustomerSkillByIdQuery : IRequest<Response>
    {
        public GetCustomerSkillByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
