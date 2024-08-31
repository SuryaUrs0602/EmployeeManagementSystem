using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectService _projectService;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IProjectService projectService, ILogger<ProjectsController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddProject(ProjectDTO projectDTO)
        //{
        //    var project = new Project
        //    {
        //        ProjectName = projectDTO.ProjectName,
        //        ProjectDuration = projectDTO.ProjectDuration
        //    };

        //    await _projectService.Add(project);
        //    return Created();
        //}

        //[HttpDelete("ProjectID")]
        //public async Task<IActionResult> DeleteProject(int ProjectID)
        //{
        //    await _projectService.Delete(ProjectID);
        //    return NoContent();
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllProjects()
        //{
        //    var data = await _projectService.GetAll();
        //    return Ok(data);
        //}

        //[HttpGet("ProjectID")]
        //public async Task<IActionResult> GetProjectByID(int ProjectID)
        //{
        //    var data = await _projectService.GetByID(ProjectID);
        //    return Ok(data);
        //}

        //[HttpGet("sortasc")]
        //public async Task<IActionResult> GetProjectByAscending()
        //{
        //    var data = await _projectService.SortByAscending();
        //    return Ok(data);
        //}

        //[HttpGet("sortdesc")]
        //public async Task<IActionResult> GetProjectByDescending()
        //{
        //    var data = await _projectService.SortByDescending();
        //    return Ok(data);
        //}

        //[HttpPut("ProjectID")]
        //public async Task<IActionResult> EditProject(int ProjectID, ProjectDTO projectDTO)
        //{
        //    var project = new Project
        //    {
        //        ProjectName = projectDTO.ProjectName,
        //        ProjectDuration = projectDTO.ProjectDuration
        //    };

        //    await _projectService.Update(ProjectID, project);
        //    return NoContent();
        //}

        [HttpPost]
        public async Task AddProject(ProjectDTO projectDTO)
        {
            var project = new Project
            {
                ProjectName = projectDTO.ProjectName,
                ProjectDuration = projectDTO.ProjectDuration
            };

            _logger.LogInformation("Creating a new Project");
            await _projectService.Add(project);
        }

        [HttpDelete("ProjectID")]
        public async Task DeleteProject(int ProjectID)
        {
            _logger.LogInformation("Deleting a Project");
            await _projectService.Delete(ProjectID);
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            _logger.LogInformation("Fetching all projects data");
            return await _projectService.GetAll();
        }

        [HttpGet("ProjectID")]
        public async Task<Project> GetProjectByID(int ProjectID)
        {
            _logger.LogInformation("Fetching project by project ID");
            return await _projectService.GetByID(ProjectID);
        }

        [HttpGet("SortAsc")]
        public async Task<IEnumerable<GetProjectDTO>> GetProjectByAscending()
        {
            _logger.LogInformation("Fetching all projects data in ascending order");
            return await _projectService.SortByAscending();
        }

        [HttpGet("SortDesc")]
        public async Task<IEnumerable<GetProjectDTO>> GetProjectByDescending()
        {
            _logger.LogInformation("Fetching all projects data in descending order");
            return await _projectService.SortByDescending();
        }

        [HttpPut("ProjectID")]
        public async Task EditProject(int ProjectID, ProjectDTO projectDTO)
        {
            var project = new Project
            {
                ProjectName = projectDTO.ProjectName,
                ProjectDuration = projectDTO.ProjectDuration
            };

            _logger.LogInformation("Updating the project");
            await _projectService.Update(ProjectID, project);
        }
    }
}
