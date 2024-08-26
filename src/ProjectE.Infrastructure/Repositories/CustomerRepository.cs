using Microsoft.EntityFrameworkCore;
using ProjectE.Core.Entities;
using ProjectE.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Infrastructure.Repositories
{
    public class CustomerRepository(ProjectEDbContext context) : ICustomerRepository
    {
        private readonly ProjectEDbContext _context = context;

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> GetCustomerByIdAsync(Guid id)
            =>   await _context.Customers.FindAsync(id);

        public async Task<Customer?> GetCustomerProjectsByIdAsync(Guid id)
        {
            var query = await _context.Customers.Include(x => x.OwnedProjects)
            .Include(x => x.FreelanceProjects).SingleOrDefaultAsync(x => x.Id == id);
            
            return query;
        }

        public async Task<bool> CustomerExistsAsync(Guid id)
            => await _context.Customers.Where(x => !x.IsDeleted).AnyAsync(x => x.Id == id); 

        public async Task<List<CustomerSkill>> GetCustomerSkillByIdAsync(Guid id)
            => await _context.CustomerSkills.Where(x => x.Id == id && !x.IsDeleted).ToListAsync();

    }
}
