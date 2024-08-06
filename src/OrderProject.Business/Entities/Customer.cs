using OrderProject.Business.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Business.Entities
{
    public class Customer
    {
        public Customer(Guid id, string name, Cpf cpf, Email email, Phone phone)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Email = email;
            Phone = phone;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; } 
        public Phone Phone { get; private set; }
        public Cpf Cpf { get; private set; } 
        public Email Email { get; private set; } 
    }
}
