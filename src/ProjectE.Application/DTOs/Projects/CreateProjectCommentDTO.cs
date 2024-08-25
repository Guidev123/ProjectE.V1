namespace ProjectE.Application.DTOs.Projects
{
    public class CreateProjectCommentDTO
    {
        public Guid CustomerId { get; set; }
        public Guid ProjectId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
