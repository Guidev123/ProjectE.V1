using ProjectE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectE.Application.DTOs.Customers
{
    public class CustomerDTO
    {
        public CustomerDTO(string name, string email, List<string> skills, List<string> ownedProjects, List<string> freelanceProjects)
        {
            Name = name;
            Email = email;
            Skills = skills;
            OwnedProjects = ownedProjects;
            FreelanceProjects = freelanceProjects;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public List<string> Skills { get; private set; }
        public List<string> OwnedProjects { get; private set; }
        public List<string> FreelanceProjects { get; private set; }
        public static CustomerDTO FromEntity(Customer customer)
        {
            var skill = customer.Skills.Select(u => u.Skill.Description).ToList();
            var ownedProjects = customer.OwnedProjects.Select(x => x.Title).ToList();
            var freelanceProjects = customer.FreelanceProjects.Select(x => x.Title).ToList();

            return new(customer.Name, customer.Email, skill, ownedProjects, freelanceProjects);
        }
    }
}
