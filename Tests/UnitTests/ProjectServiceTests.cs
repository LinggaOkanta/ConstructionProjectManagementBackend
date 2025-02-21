//// tests/UnitTests/ProjectServiceTests.cs
//using Xunit;
//using Moq;
//using ConstructionProjectManagement.Application.DTOs;
//using ConstructionProjectManagement.Domain.Entities;
//using ConstructionProjectManagement.Domain.Interfaces;

//public class ProjectServiceTests
//{
//    [Fact]
//    public async Task UpdateProjectAsync_ShouldUpdateProject()
//    {
//        // Arrange
//        var mockRepo = new Mock<IConstructionProjectRepository>();
//        var projectService = new ConstructionProject(mockRepo.Object);

//        var project = new ConstructionProject
//        {
//            ProjectId = 1,
//            ProjectName = "Test Project",
//            ProjectStage = "Concept",
//            ProjectCategory = "Education",
//            ConstructionStartDate = DateTime.Now.AddDays(10),
//            ProjectDetails = "Test Details"
//        };

//        mockRepo.Setup(repo => repo.GetProjectByIdAsync(1)).ReturnsAsync(project);
//        mockRepo.Setup(repo => repo.UpdateProjectAsync(project)).Returns(Task.CompletedTask);

//        // Act
//        await projectService.UpdateProjectAsync(1, new EditProjectRequest
//        {
//            ProjectName = "Updated Project",
//            ProjectStage = "Design & Documentation",
//            ProjectCategory = "Health",
//            ConstructionStartDate = DateTime.Now.AddDays(20),
//            ProjectDetails = "Updated Details"
//        });

//        // Assert
//        mockRepo.Verify(repo => repo.UpdateProjectAsync(project), Times.Once);
//    }

//    [Fact]
//    public async Task DeleteProjectAsync_ShouldDeleteProject()
//    {
//        // Arrange
//        var mockRepo = new Mock<IConstructionProjectRepository>();
//        var projectService = new ConstructionProject(mockRepo.Object);

//        var project = new ConstructionProject
//        {
//            ProjectId = 1,
//            ProjectName = "Test Project",
//            ProjectStage = "Concept",
//            ProjectCategory = "Education",
//            ConstructionStartDate = DateTime.Now.AddDays(10),
//            ProjectDetails = "Test Details"
//        };

//        mockRepo.Setup(repo => repo.GetProjectByIdAsync(1)).ReturnsAsync(project);
//        mockRepo.Setup(repo => repo.DeleteProjectAsync(1)).Returns(Task.CompletedTask);

//        // Act
//        await projectService.DeleteProjectAsync(1);

//        // Assert
//        mockRepo.Verify(repo => repo.DeleteProjectAsync(1), Times.Once);
//    }
//}