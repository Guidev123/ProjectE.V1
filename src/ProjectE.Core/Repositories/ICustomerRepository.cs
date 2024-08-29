using ProjectE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerById(Guid id);
        Task<Customer?> GetCustomerProjectsByIdAsync(Guid id);
        Task<Customer?> GetCustomerSkillsByIdAsync(Guid id);
        Task<Customer?> GetCustomerByEmailAndPasswordAsync(string email, string passwordHash);
        Task<Skill> CreateCustomerSkillAsync(Skill skill);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<bool> CustomerExistsAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
    }
}
