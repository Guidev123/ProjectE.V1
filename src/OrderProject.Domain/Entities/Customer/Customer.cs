using OrderProject.Domain.ValueObject;

namespace OrderProject.Domain.Entities.Customer
{
    public class Customer : Entity
    {
        protected Customer()
        {
            
        }
        public Customer(string name, string cpf, string email, string phone)
        {
            Name = name;
            Cpf = new Cpf(cpf);
            Email = new Email(email);
            Phone = new Phone(phone);
            Orders = [];
        }
        public string? Name { get; private set; }
        public Email? Email { get; private set; }
        public Phone? Phone { get; private set; }
        public Cpf? Cpf { get; private set; }

        // EF rel
        public List<Entities.Order.Order>? Orders { get; set; }
    }
}
