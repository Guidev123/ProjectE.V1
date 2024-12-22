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
        Task<Customer?> GetById(Guid id);
        Task<Customer?> GetProjectsByIdAsync(Guid id);
        Task<Customer?> GetSkillsByIdAsync(Guid id);
        Task<Customer?> GetByEmailAndPasswordAsync(string email, string passwordHash);
        Task<Skill> CreateSkillAsync(Skill skill);
        Task<Customer> CreateAsync(Customer customer);
        Task<bool> ExistsAsync(Customer customer);
        Task UpdateAsync(Customer customer);
    }
}
