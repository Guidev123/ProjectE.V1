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

        public async Task<Customer?> GetCustomerSkillsByIdAsync(Guid id)
            =>   await _context.Customers.Include(x => x.Skills).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Customer?> GetCustomerProjectsByIdAsync(Guid id)
        {
            var query = await _context.Customers.Include(x => x.OwnedProjects)
            .Include(x => x.FreelanceProjects).SingleOrDefaultAsync(x => x.Id == id);
            
            return query;
        }

        public async Task<bool> CustomerExistsAsync(Customer customer)
            => await _context.Customers.Where(x => !x.IsDeleted).AnyAsync(x => x.Id == customer.Id || x.Email == customer.Email);

        public async Task<Skill> CreateCustomerSkillAsync(Skill skill)
        {
           await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<Customer?> GetCustomerById(Guid id)
            => await _context.Customers.Include(x => x.OwnedProjects)
            .Include(x => x.FreelanceProjects).Include(x => x.Skills).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Customer?> GetCustomerByEmailAndPasswordAsync(string email, string passwordHash)
            => await _context.Customers.SingleOrDefaultAsync(x => x.Email == email && x.Password == passwordHash);
    }
}
