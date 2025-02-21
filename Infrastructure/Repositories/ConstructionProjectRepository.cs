using ConstructionProjectManagement.Domain.Entities;
using ConstructionProjectManagement.Domain.Interfaces;
using ConstructionProjectManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nest;

namespace ConstructionProjectManagement.Infrastructure.Repositories
{
    public class ConstructionProjectRepository : IConstructionProjectRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ConstructionProjectRepository> _logger;

        public ConstructionProjectRepository(AppDbContext context, ILogger<ConstructionProjectRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ConstructionProject>> GetAllAsync()
        {
            return await _context.ConstructionProjects.ToListAsync();
        }

        public async Task<ConstructionProject> GetByIdAsync(int id)
        {
            return await _context.ConstructionProjects.FindAsync(id);
        }

        public async Task AddAsync(ConstructionProject project)
        {
            _logger.LogInformation($"Adding project with {string.Join(",", project)}");
            await _context.ConstructionProjects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task<ConstructionProject> GetProjectByIdAsync(int id)
        {
            return await _context.ConstructionProjects.FindAsync(id);
        }

        public async Task UpdateProjectAsync(ConstructionProject project)
        {
            _logger.LogInformation("Updating project with ID: {ProjectId}", project.ProjectId);
            _context.ConstructionProjects.Update(project);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProjectAsync(int id)
        {
            _logger.LogInformation("Deleting project with ID: {ProjectId}", id);
            var project = await _context.ConstructionProjects.FindAsync(id);
            if (project != null)
            {
                _context.ConstructionProjects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}
