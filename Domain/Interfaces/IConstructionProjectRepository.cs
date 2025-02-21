using ConstructionProjectManagement.Domain.Entities;

namespace ConstructionProjectManagement.Domain.Interfaces
{
    public interface IConstructionProjectRepository
    {
        Task<IEnumerable<ConstructionProject>> GetAllAsync();
        Task<ConstructionProject> GetByIdAsync(int id);
        Task AddAsync(ConstructionProject project);
        Task<ConstructionProject> GetProjectByIdAsync(int id);
        Task UpdateProjectAsync(ConstructionProject project);
        Task DeleteProjectAsync(int id);
    }
}
