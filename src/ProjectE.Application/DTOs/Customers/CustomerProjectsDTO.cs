using ProjectE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.DTOs.Customers
{
    public class CustomerProjectsDTO
    {
        public CustomerProjectsDTO(string name, string email, List<string> ownedProjects, List<string> freelanceProjects)
        {
            Name = name;
            Email = email;
            OwnedProjects = ownedProjects;
            FreelanceProjects = freelanceProjects;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public List<string> OwnedProjects { get; private set; }
        public List<string> FreelanceProjects { get; private set; }
        public static CustomerProjectsDTO FromEntity(Customer customer)
        {
            var ownedProjects = customer.OwnedProjects.Select(x => x.Title).ToList();
            var freelanceProjects = customer.FreelanceProjects.Select(x => x.Title).ToList();

            return new(customer.Name, customer.Email, ownedProjects, freelanceProjects);
        }
    }
}
