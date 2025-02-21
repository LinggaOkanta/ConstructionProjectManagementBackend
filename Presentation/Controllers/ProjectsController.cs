using ConstructionProjectManagement.Application.DTOs;
using ConstructionProjectManagement.Application.Services;
using ConstructionProjectManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionProjectManagement.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ConstructionProjectService _service;

        public ProjectsController(ConstructionProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var projects = await _service.GetAllProjectsAsync();
                return Ok(projects);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the project.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var project = await _service.GetProjectByIdAsync(id);
                if (project == null) return NotFound();
                return Ok(project);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the project.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConstructionProjectDto projectDto)
        {
            try
            {
                var project = new ConstructionProject
                {
                    ProjectName = projectDto.ProjectName,
                    ProjectLocation = projectDto.ProjectLocation,
                    ProjectStage = projectDto.ProjectStage,
                    ProjectCategory = projectDto.ProjectCategory,
                    ConstructionStartDate = DateTime.SpecifyKind(projectDto.ConstructionStartDate, DateTimeKind.Utc),
                    ProjectDetails = projectDto.ProjectDetails,
                    CreatorId = projectDto.CreatorId
                };

                await _service.AddProjectAsync(project);
                return CreatedAtAction(nameof(GetById), new { id = project.ProjectId }, project);

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the project.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] EditProjectRequest request)
        {
            try
            {
                await _service.UpdateProjectAsync(id, request);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the project.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                await _service.DeleteProjectAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the project.");
            }
        }
    }
}
