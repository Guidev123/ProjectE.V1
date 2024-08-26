namespace ProjectE.Application.DTOs.Skills
{
    public class CustomerSkillsDTO
    {
        public Guid Id { get; set; }
        public Guid[] SkillIds { get; set; } = [];
    }
}
