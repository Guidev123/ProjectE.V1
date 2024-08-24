using ProjectE.Core.Entities;

namespace ProjectE.Application.DTOs.Projects
{
    public class CreateProjectDTO
    {
        public Guid CustomerId { get; set; }
        public Guid FreelancerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }

        public Project ToEntity()
            => new(CustomerId, FreelancerId, Title, Description, TotalPrice);

    }
}
