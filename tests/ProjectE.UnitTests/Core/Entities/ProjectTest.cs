using ProjectE.Core.Entities;
using ProjectE.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.UnitTests.Core.Entities
{
    public class ProjectTest
    {
        public Guid customer = Guid.NewGuid();
        public Guid freelancer = Guid.NewGuid();   

        [Fact]
        public void Should_Start_Project()
        {
            Project project = new Project(customer, freelancer, "Projeto teste", "Projeto teste descricao", 1000M);

            Assert.Equal(EProjectStatus.Created, project.ProjectStatus);
            Assert.Null(project.StartedAt);

            project.Start();

            Assert.Equal(EProjectStatus.InProgress, project.ProjectStatus);
            Assert.NotNull(project.StartedAt);
        }
    }
}
