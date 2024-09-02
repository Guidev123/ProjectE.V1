using MediatR;
using ProjectE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Projects.CompleteProject
{
    public class CompleteProjectCommand : IRequest<Response>
    {
        public CompleteProjectCommand(Guid id, string creditCardNumber, string cvv, string expiresAt, string fullName)
        {
            Id = id;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
        }
        public Guid Id { get; private set; }
        public string CreditCardNumber { get; private set; }
        public string Cvv { get; private set; }
        public string ExpiresAt { get; private set; }
        public string FullName { get; private set; }
    }
}
