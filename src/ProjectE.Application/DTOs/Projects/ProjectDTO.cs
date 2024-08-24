using ProjectE.Core.Entities;

namespace ProjectE.Application.DTOs.Projects
{
    public class ProjectDTO
    {
        public ProjectDTO(Guid id, string title, string description, string customerName, string freelancerName,
                          decimal totalPrice, Guid customerId, Guid freelancerId, List<ProjectComment> comments)
        {
            Id = id;
            Title = title;
            Description = description;
            CustomerName = customerName;
            FreelancerName = freelancerName;
            TotalPrice = totalPrice;
            CustomerId = customerId;
            FreelancerId = freelancerId;
            Comments = comments.Select(x => x.Content).ToList();
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string CustomerName { get; private set; }
        public string FreelancerName { get; private set; }
        public decimal TotalPrice { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid FreelancerId { get; private set; }
        public List<string?> Comments { get; private set; }

        public static ProjectDTO FromEntity(Project entity) => new(entity.Id, entity.Title, entity.Description, entity.Customer.Name,
                                                                   entity.Freelancer.Name, entity.TotalPrice, entity.CustomerId,
                                                                   entity.FreelancerId, entity.Comments);
    }
}
