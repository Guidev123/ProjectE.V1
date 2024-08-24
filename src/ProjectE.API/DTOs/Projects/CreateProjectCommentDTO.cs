namespace ProjectE.API.DTOs.Projects
{
    public class CreateProjectCommentDTO
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
