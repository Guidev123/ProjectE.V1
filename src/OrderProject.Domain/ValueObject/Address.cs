using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Domain.ValueObject
{
    public record Address(string Street, string Number,
                          string Complement, string Neighborhood,
                          string PostalCode, string City, string State);
}
