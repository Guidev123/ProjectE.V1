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
        Task<Customer?> GetCustomerProjectsByIdAsync(Guid id);
        Task<Customer?> GetCustomerByIdAsync(Guid id);
        Task<List<CustomerSkill>> GetCustomerSkillByIdAsync(Guid id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<bool> CustomerExistsAsync(Guid id);
        Task UpdateCustomerAsync(Customer customer);
    }
}
