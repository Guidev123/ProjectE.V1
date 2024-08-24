namespace ProjectE.API.DTOs.Projects
{
    public class UpdateProjectDTO
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
    }
}
