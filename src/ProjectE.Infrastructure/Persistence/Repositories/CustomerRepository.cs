using Microsoft.EntityFrameworkCore;
using ProjectE.Core.Entities;
using ProjectE.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository(ProjectEDbContext context) : ICustomerRepository
    {
        private readonly ProjectEDbContext _context = context;

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> GetSkillsByIdAsync(Guid id)
            => await _context.Customers.Include(x => x.Skills).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Customer?> GetProjectsByIdAsync(Guid id)
        {
            var query = await _context.Customers.Include(x => x.OwnedProjects)
            .Include(x => x.FreelanceProjects).SingleOrDefaultAsync(x => x.Id == id);

            return query;
        }

        public async Task<bool> ExistsAsync(Customer customer)
            => await _context.Customers.Where(x => !x.IsDeleted).AnyAsync(x => x.Id == customer.Id || x.Email == customer.Email);

        public async Task<Skill> CreateSkillAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<Customer?> GetById(Guid id)
            => await _context.Customers.Include(x => x.OwnedProjects)
            .Include(x => x.FreelanceProjects).Include(x => x.Skills).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Customer?> GetByEmailAndPasswordAsync(string email, string passwordHash)
            => await _context.Customers.SingleOrDefaultAsync(x => x.Email == email && x.Password == passwordHash);
    }
}
