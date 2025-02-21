using System;

namespace ConstructionProjectManagement.Domain.Entities
{
    public class ConstructionProject
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLocation { get; set; }
        public string ProjectStage { get; set; }
        public string ProjectCategory { get; set; }
        public DateTime ConstructionStartDate { get; set; }
        public string ProjectDetails { get; set; }
        public Guid CreatorId { get; set; }
    }
}
