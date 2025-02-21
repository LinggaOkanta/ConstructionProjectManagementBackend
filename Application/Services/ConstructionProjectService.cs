using ConstructionProjectManagement.Application.DTOs;
using ConstructionProjectManagement.Domain.Entities;
using ConstructionProjectManagement.Domain.Interfaces;
using ConstructionProjectManagement.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Nest;

namespace ConstructionProjectManagement.Application.Services
{
    public class ConstructionProjectService
    {
        private readonly IConstructionProjectRepository _repository;
        private readonly ILogger<ConstructionProjectService> _logger;

        public ConstructionProjectService(IConstructionProjectRepository repository, ILogger<ConstructionProjectService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<ConstructionProject>> GetAllProjectsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ConstructionProject> GetProjectByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddProjectAsync(ConstructionProject project)
        {
            await _repository.AddAsync(project);
        }

        public async Task UpdateProjectAsync(int id, EditProjectRequest request)
        {

            _logger.LogInformation("Updating project with ID: {ProjectId}", id);
            var project = await _repository.GetProjectByIdAsync(id);
            if (project == null)
            {
                throw new KeyNotFoundException("Project not found.");
            }
            project.ProjectId = id;
            project.ProjectName = request.ProjectName;
            project.ProjectStage = request.ProjectStage;
            project.ProjectCategory = request.ProjectCategory;
            project.ConstructionStartDate = request.ConstructionStartDate;
            project.ProjectDetails = request.ProjectDetails;
            project.CreatorId = request.CreatorId;

            await _repository.UpdateProjectAsync(project);

            _logger.LogInformation("Project with ID: {ProjectId} updated successfully.", id);

        }

        public async Task DeleteProjectAsync(int id)
        {
            _logger.LogInformation("Deleting project with ID: {ProjectId}", id);
            var project = await _repository.GetProjectByIdAsync(id);
            if (project == null)
            {
                throw new KeyNotFoundException("Project not found.");
            }

            await _repository.DeleteProjectAsync(id);
            _logger.LogInformation("Deleting with ID: {ProjectId} updated successfully.", id);
        }
    }
}
