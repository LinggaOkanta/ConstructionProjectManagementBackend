namespace ConstructionProjectManagement.Application.DTOs
{
    public class EditProjectRequest
    {
        public string ProjectName { get; set; }
        public string ProjectStage { get; set; }
        public string ProjectCategory { get; set; }
        public DateTime ConstructionStartDate { get; set; }
        public string ProjectDetails { get; set; }
        public Guid CreatorId { get; set; }
    }
}
