using ProjectE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.DTOs.Skills
{
    public class CustomerSkillsDTO
    {
        public CustomerSkillsDTO(string name, string email, List<string> skills)
        {
            Name = name;
            Email = email;
            Skills = skills;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public List<string> Skills { get; private set; }
        public static CustomerSkillsDTO FromEntity(Customer customer)
        {
            var skill = customer.Skills.Select(u => u.Description).ToList();

            return new(customer.Name, customer.Email, skill);
        }
    }
}
