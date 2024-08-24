using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Core.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, string email, DateTime birthDate, bool active) : base()
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Active = true;
            Skills = [];
            ProjectComments = [];
            OwnedProjects = [];
            FreelanceProjects = [];
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; private set; }
        public List<CustomerSkill> Skills { get; private set; }
        public List<ProjectComment> ProjectComments { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
    }
}
