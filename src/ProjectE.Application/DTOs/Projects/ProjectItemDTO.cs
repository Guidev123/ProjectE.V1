using ProjectE.Core.Entities;

namespace ProjectE.Application.DTOs.Projects
{
    public class ProjectItemDTO
    {
        public ProjectItemDTO(Guid id, string title, string customerName, string freelancerName, decimal totalPrice)
        {
            Id = id;
            Title = title;
            CustomerName = customerName;
            FreelancerName = freelancerName;
            TotalPrice = totalPrice;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string CustomerName { get; private set; }
        public string FreelancerName { get; private set; }
        public decimal TotalPrice { get; private set; }

        public static ProjectItemDTO FromEntity(Project project)
            => new(project.Id, project.Title, project.Customer.Name, project.Freelancer.Name, project.TotalPrice);
    }
}
