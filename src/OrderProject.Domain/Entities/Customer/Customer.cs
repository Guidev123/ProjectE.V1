using OrderProject.Domain.Entities;
using OrderProject.Domain.Entities.Order;
using OrderProject.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Domain.Entities.Customer
{
    public class Customer : Entity
    {
        public Customer(string name, Cpf cpf, Email email, Phone phone, Address adress)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Phone = phone;
            Adress = adress;
        }
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public Cpf Cpf { get; private set; }
        public Address Adress { get; set; }
    }
}
